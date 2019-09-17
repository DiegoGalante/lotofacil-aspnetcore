﻿using System;
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
    public class Person_LotteryAppService : IPerson_LotteryAppService
    {
        private readonly IMapper _mapper;
        private readonly IPerson_LotteryRepository _person_lotteryRepository;
        private readonly IUtilitiesAppService _utilitiesAppService;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public Person_LotteryAppService(IMapper mapper,
                                        IPerson_LotteryRepository person_lotteryRepository,
                                        IUtilitiesAppService utilitiesAppService,
                                        IEventStoreRepository eventStoreRepository,
                                        IMediatorHandler bus)
        {
            _mapper = mapper;
            _person_lotteryRepository = person_lotteryRepository;
            _utilitiesAppService = utilitiesAppService;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;
        }

        public void Register(Person_LotteryViewModel Person_LotteryViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewPerson_LotteryCommand>(Person_LotteryViewModel);
            Bus.SendCommand(registerCommand);
        }

        IEnumerable<Person_LotteryViewModel> IPerson_LotteryAppService.GetAll()
        {
            return _person_lotteryRepository.GetAll().ProjectTo<Person_LotteryViewModel>(_mapper.ConfigurationProvider);
        }

        public void Update(Person_LotteryViewModel Person_LotteryViewModel)
        {
            var updateCommand = _mapper.Map<UpdatePerson_LotteryCommand>(Person_LotteryViewModel);
            Bus.SendCommand(updateCommand);
        }

        public Person_LotteryViewModel GetById(Guid id)
        {
            return _mapper.Map<Person_LotteryViewModel>(_person_lotteryRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemovePerson_LotteryCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public Object GetJsonDashboard(int concurse = 0)
        {
            //_person_lotteryRepository.GetFunctionJsonDashBoard(0);

            //object retorno = new { concurse = _person_lotteryRepository.GetFunctionJsonDashBoard(concurse), personGame = _person_lotteryRepository.GetFunctionJogoPessoa(concurse) };

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
            return _person_lotteryRepository.GetFunctionJogoPessoa(personId, concurse);
        }

        public Object GetPersonGame(int concurse = 0)
        {
            //return _person_lotteryRepository.GetFunctionJogoPessoa(concurse);

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
