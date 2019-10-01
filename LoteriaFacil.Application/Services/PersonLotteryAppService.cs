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
using LoteriaFacil.Infra.Data.Repository.EventSourcing;
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

        public PersonLotteryAppService(IMapper mapper,
                                        IPersonLotteryRepository PersonLotteryRepository,
                                        ILotteryRepository lotteryRepository,
                                        IUtilitiesAppService utilitiesAppService,
                                        IEventStoreRepository eventStoreRepository,
                                        IMediatorHandler bus,

                                        IJsonDashboardRepository jsonDashboardRepository,
                                        IPersonGameRepository personGameRepository,
                                        IPersonRepository personRepository,
                                        IConfigurationRepository configurationRepository)
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
                concurse = lottery.Concurse;

            lottery = _LotteryRepository.GetByConcurse(concurse);

            List<PersonGame> personGame = _personGameRepository.GetFunctionJogosConcurso(concurse, configuration.Calcular_Dezenas_Sem_Pontuacao).ToList();
            foreach (var pessoa in personGame)
                pessoas.Add(_personRepository.GetById(pessoa.PesId));

            //PersonLottery personLottery = _PersonLotteryRepository.GetByConcurse(concurse);

            decimal total_bilhetes = personGame.Sum(x => x.Ticket_Amount);

          var retorno =  _utilitiesAppService.MontaHtml(lottery, personGame);
            return new { ret = true, msg = "" };
        }
    }
}
