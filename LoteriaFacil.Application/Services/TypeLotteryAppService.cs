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
    public class TypeLotteryAppService : ITypeLotteryAppService
    {
        private readonly IMapper _mapper;
        private readonly ITypeLotteryRepository _TypeLotteryRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public TypeLotteryAppService(
            IMapper mapper,
            ITypeLotteryRepository TypeLotteryRepository,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository)
        {
            this._mapper = mapper;
            this._TypeLotteryRepository = TypeLotteryRepository;
            this.Bus = bus;
            this._eventStoreRepository = eventStoreRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TypeLotteryViewModel> GetAll()
        {
            return _TypeLotteryRepository.GetAll().ProjectTo<TypeLotteryViewModel>(_mapper.ConfigurationProvider);
        }

        public TypeLotteryViewModel GetById(Guid id)
        {
            return _mapper.Map<TypeLotteryViewModel>(_TypeLotteryRepository.GetById(id));
        }

        public TypeLotteryViewModel GetByName(string name = "Loto Fácil")
        {
            return _mapper.Map<TypeLotteryViewModel>(_TypeLotteryRepository.GetByName(name));
        }

        public void Register(TypeLotteryViewModel TypeLotteryViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewTypeLotteryCommand>(TypeLotteryViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveTypeLotteryCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(TypeLotteryViewModel TypeLotteryViewModel)
        {
            var updateCommand = _mapper.Map<UpdateTypeLotteryCommand>(TypeLotteryViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
