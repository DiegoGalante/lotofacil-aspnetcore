using AutoMapper;
using AutoMapper.QueryableExtensions;
using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Application.ViewModels;
using LoteriaFacil.Domain.Commands;
using LoteriaFacil.Domain.Core.Bus;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;

namespace LoteriaFacil.Application.Services
{
    public class Type_LotteryAppService : IType_LotteryAppService
    {
        private readonly IMapper _mapper;
        private readonly IType_LotteryRepository _type_LotteryRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public Type_LotteryAppService(
            IMapper mapper,
            IType_LotteryRepository type_LotteryRepository,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository)
        {
            this._mapper = mapper;
            this._type_LotteryRepository = type_LotteryRepository;
            this.Bus = bus;
            this._eventStoreRepository = eventStoreRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Type_LotteryViewModel> GetAll()
        {
            return _type_LotteryRepository.GetAll().ProjectTo<Type_LotteryViewModel>(_mapper.ConfigurationProvider);
        }

        public Type_LotteryViewModel GetById(Guid id)
        {
            return _mapper.Map<Type_LotteryViewModel>(_type_LotteryRepository.GetById(id));
        }

        public Type_LotteryViewModel GetByName(string name = "Loto Fácil")
        {
            return _mapper.Map<Type_LotteryViewModel>(_type_LotteryRepository.GetByName(name));
        }

        public void Register(Type_LotteryViewModel type_LotteryViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewType_LotteryCommand>(type_LotteryViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveType_LotteryCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(Type_LotteryViewModel type_LotteryViewModel)
        {
            var updateCommand = _mapper.Map<UpdateType_LotteryCommand>(type_LotteryViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
