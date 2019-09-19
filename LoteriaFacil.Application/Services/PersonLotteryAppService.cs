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

        public PersonLotteryAppService(IMapper mapper,
                                        IPersonLotteryRepository PersonLotteryRepository,
                                        ILotteryRepository lotteryRepository,
                                        IUtilitiesAppService utilitiesAppService,
                                        IEventStoreRepository eventStoreRepository,
                                        IMediatorHandler bus)
        {
            _mapper = mapper;
            _PersonLotteryRepository = PersonLotteryRepository;
            _LotteryRepository = lotteryRepository;
            _utilitiesAppService = utilitiesAppService;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;
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
            if (concurse == 0)
                concurse = _LotteryRepository.GetLast().Concurse;

            _PersonLotteryRepository.GetFunctionJsonDashBoard(concurse);

            //object retorno = new { concurse = _PersonLotteryRepository.GetFunctionJsonDashBoard(concurse), personGame = _PersonLotteryRepository.GetFunctionJogoPessoa(concurse) };

            object tt = new
            {
                concurse = 123,
                dtConcurse = DateTime.Now.ToShortDateString(),
                dtExtense = _utilitiesAppService.DataPorExtenso(DateTime.Now),
                game = "01-02-03-04-05-06-07-08-09-10-11-12-13-14-15",
                hit15 = 0,
                shared15 = 0,
                percent15 = 0,

                hit14 = 0,
                shared14 = 0,
                percent14 = -7,

                hit13 = 0,
                shared13 = 0,
                percent13 = 3,

                hit12 = 0,
                shared12 = 0,
                percent12 = 2,

                hit11 = 0,
                shared11 = 0,
                percent11 = 15,
            };



            decimal valor = (decimal)7.36;

            object retorno = new { concurse = tt, personGame = "", amount_tickets = valor };

            return retorno;

        }

        public Object GetPersonGame(Guid personId, int concurse = 0)
        {
            return null;
            return _PersonLotteryRepository.GetFunctionJogoPessoa(personId, concurse);
        }

        public Object GetPersonGame(int concurse = 0)
        {
            //return _PersonLotteryRepository.GetFunctionJogoPessoa(concurse);

            object person = new[]
            {
               new  { id = 123, name = "Pessoa Teste1", concurse = 123, game = "01-02-03-04-05-19-07-08-09-22-11-12-13-14-15", hits = 13, amount = (decimal)4.68 },
               new  { id = 321, name = "Pessoa Teste2", concurse = 123, game = "01-02-03-04-05-19-07-21-10-25-11-12-13-14-15", hits = 11, amount = (decimal)2.68 },
               new  { id = 322, name = "Pessoa Teste3", concurse = 123, game = "01-02-03-04-05-19-07-21-10-25-11-12-13-14-15", hits = 11, amount = (decimal)2.68 },
               new  { id = 323, name = "Pessoa Teste4", concurse = 123, game = "01-02-03-04-05-19-07-21-10-25-11-12-13-14-15", hits = 11, amount = (decimal)2.68 },
               new  { id = 324, name = "Pessoa Teste5", concurse = 123, game = "01-02-03-04-05-19-07-21-10-25-11-12-13-14-15", hits = 11, amount = (decimal)2.68 },
               new  { id = 325, name = "Pessoa Teste6", concurse = 123, game = "01-02-03-04-05-19-07-21-10-25-11-12-13-14-15", hits = 11, amount = (decimal)2.68 },
               new  { id = 326, name = "Pessoa Teste7", concurse = 123, game = "01-02-03-04-05-17-07-21-10-25-11-12-13-14-15", hits = 11, amount = (decimal)2.68 },
               new  { id = 327, name = "Pessoa Teste8", concurse = 123, game = "01-02-03-04-05-19-07-21-10-25-11-12-13-14-15", hits = 11, amount = (decimal)2.68 },
               new  { id = 328, name = "Pessoa Teste9", concurse = 123, game = "01-02-03-04-05-19-07-21-10-25-11-12-13-14-15", hits = 11, amount = (decimal)2.68 },
               new  { id = 329, name = "Pessoa Teste10", concurse = 123, game = "01-02-03-04-05-19-07-21-10-25-11-12-13-14-15", hits = 11, amount = (decimal)2.68 }
            };

            return person;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
