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
    public class Person_LotteryAppService : IPerson_LotteryAppService
    {
        private readonly IMapper _mapper;
        private readonly IPerson_LotteryRepository _person_lotteryRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public Person_LotteryAppService(IMapper mapper,
                                        IPerson_LotteryRepository person_lotteryRepository,
                                        IEventStoreRepository eventStoreRepository,
                                        IMediatorHandler bus)
        {
            _mapper = mapper;
            _person_lotteryRepository = person_lotteryRepository;
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
