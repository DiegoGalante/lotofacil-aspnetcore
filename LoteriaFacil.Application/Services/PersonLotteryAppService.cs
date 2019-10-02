using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
//using LoteriaFacil.Application.EventSourcedNormalizers;
using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Application.ViewModels;
using LoteriaFacil.Domain.Commands;
using LoteriaFacil.Domain.Core.Bus;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Domain.Models;
using LoteriaFacil.Infra.CrossCutting.Identity.Services;
using LoteriaFacil.Infra.CrossCutting.Identity.Extensions;
using LoteriaFacil.Infra.Data.Repository.EventSourcing;
using LoteriaFacil.Infra.CrossCutting.Identity.Offline;

namespace LoteriaFacil.Application.Services
{
    public class PersonLotteryAppService : IPersonLotteryAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonLotteryRepository _PersonLotteryRepository;
        private readonly ILotteryRepository _LotteryRepository;
        private readonly IUtilitiesAppService _utilitiesAppService;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        private readonly IJsonDashboardRepository _jsonDashboardRepository;
        private readonly IPersonGameRepository _personGameRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IConfigurationRepository _configurationRepository;

        private readonly IEmailSender _emailSender;

        public PersonLotteryAppService(IMapper mapper,
                                        IPersonLotteryRepository PersonLotteryRepository,
                                        ILotteryRepository lotteryRepository,
                                        IUtilitiesAppService utilitiesAppService,
                                        IEventStoreRepository eventStoreRepository,
                                        IMediatorHandler bus,

                                        IJsonDashboardRepository jsonDashboardRepository,
                                        IPersonGameRepository personGameRepository,
                                        IPersonRepository personRepository,
                                        IConfigurationRepository configurationRepository,
                                        IEmailSender emailSender)
        {
            _mapper = mapper;
            _PersonLotteryRepository = PersonLotteryRepository;
            _LotteryRepository = lotteryRepository;
            _utilitiesAppService = utilitiesAppService;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;

            _jsonDashboardRepository = jsonDashboardRepository;
            _personGameRepository = personGameRepository;
            _personRepository = personRepository;
            _configurationRepository = configurationRepository;

            _emailSender = emailSender;
        }

        public void Register(PersonLotteryViewModel PersonLotteryViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewPersonLotteryCommand>(PersonLotteryViewModel);
            Bus.SendCommand(registerCommand);
        }

        IEnumerable<PersonLotteryViewModel> IPersonLotteryAppService.GetAll()
        {
            return _PersonLotteryRepository.GetAll().ProjectTo<PersonLotteryViewModel>(_mapper.ConfigurationProvider);
        }

        public void Update(PersonLotteryViewModel PersonLotteryViewModel)
        {
            var updateCommand = _mapper.Map<UpdatePersonLotteryCommand>(PersonLotteryViewModel);
            Bus.SendCommand(updateCommand);
        }

        public PersonLotteryViewModel GetById(Guid id)
        {
            return _mapper.Map<PersonLotteryViewModel>(_PersonLotteryRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemovePersonLotteryCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public Object GetJsonDashboard(int concurse = 0)
        {
            JsonDashboard lottery = new JsonDashboard();
            if (concurse > 0)
                lottery = _jsonDashboardRepository.GetFunctionJsonDashBoard(concurse);

            if (lottery == null || lottery.Id.Equals(Guid.Empty))
                lottery = _jsonDashboardRepository.GetFunctionJsonDashBoard(_LotteryRepository.GetLast().Concurse);

            return new { concurse = lottery, personGame = "", amount_tickets = 0 };
        }

        internal List<PersonGame> PersonGame(out decimal amount, int concurse = 0, Guid? personId = null)
        {
            List<PersonGame> _personGame = new List<PersonGame>();
            Configuration configuration = _configurationRepository.GetFirst();

            if (concurse == 0)
                concurse = _LotteryRepository.GetLast().Concurse;

            if (personId != null)
            {
                _LotteryRepository.SetProcedureSP_CHECK_GAME(concurse, (Guid)personId);
                _personGame = _personGameRepository.GetFunctionJogoPessoa((Guid)personId, concurse, configuration.Calcular_Dezenas_Sem_Pontuacao).ToList();
            }
            else
            {
                _LotteryRepository.SetProcedureSP_CHECK_GAME(concurse);
                _personGame = _personGameRepository.GetFunctionJogosConcurso(concurse, configuration.Calcular_Dezenas_Sem_Pontuacao).ToList();
            }

            amount = _personGame.Sum(x => x.Ticket_Amount);

            return _personGame;
        }

        public Object GetPersonGame(Guid personId, int concurse = 0)
        {
            decimal amount = 0;
            List<PersonGame> _personGame = PersonGame(out amount, concurse, personId);

            return new { personGame = _personGame, amount_tickets = amount };
        }

        public Object GetPersonGame(int concurse = 0)
        {
            decimal amount = 0;
            List<PersonGame> _personGame = PersonGame(out amount, concurse);

            return new { personGame = _personGame, amount_tickets = amount };
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Object SendEmail(int concurse = 0)
        {
            Lottery lottery = new Lottery();
            List<Person> pessoas = new List<Person>();
            Configuration configuration = _configurationRepository.GetFirst();

            if (concurse == 0)
                concurse = _LotteryRepository.GetLast().Concurse;

            lottery = _LotteryRepository.GetByConcurse(concurse);

            List<PersonGame> personGame = _personGameRepository.GetFunctionJogosConcurso(concurse, configuration.Calcular_Dezenas_Sem_Pontuacao, configuration.Valor_Minimo_Para_Envio_Email).ToList();
            foreach (var pes in personGame)
            {
                Person pessoa = _personRepository.GetById(pes.PesId);
                if (!pessoas.Contains(pessoa))
                    pessoas.Add(pessoa);
            }

            var assunto = "Lotofácil - Diego Galante";
            var corpoEmail = "";
            decimal total_bilhetes = 0;

            //Configuração de enviar email exclusivo para pessoa
            if (true)
            {
                foreach (var pessoa in pessoas)
                {
                    total_bilhetes = personGame.Where(x => x.PesId == pessoa.Id).Sum(x => x.Ticket_Amount);

                    List<PersonGame> pesGame = _personGameRepository.GetFunctionJogoPessoa(pessoa.Id, lottery.Concurse, configuration.Calcular_Dezenas_Sem_Pontuacao, configuration.Valor_Minimo_Para_Envio_Email).ToList();
                    corpoEmail = _utilitiesAppService.MontaHtml(lottery, pesGame);
                    _emailSender.SendEmailJogosPessoa(pessoa.Email, corpoEmail, assunto);

                    total_bilhetes = 0;
                    corpoEmail = string.Empty;
                }
            }
            else
            {
                //Basicamente aqui todo mundo que registrou jogo recebe o email com os nomes, apostas e acertos de todos.
                //Não vou manter isso aqui, só mesmo pra teste e debug ;D
                total_bilhetes = personGame.Sum(x => x.Ticket_Amount);
                corpoEmail = _utilitiesAppService.MontaHtml(lottery, personGame);
                foreach (var pessoa in pessoas)
                    _emailSender.SendEmailJogosPessoa(Credenciais.EMAIL_ADM, corpoEmail, assunto);
                //_emailSender.SendEmailJogosPessoa(pessoa.Email, corpoEmail, assunto);

                total_bilhetes = 0;
                corpoEmail = string.Empty;
            }




            return new { ret = true, msg = "" };
        }
    }
}
