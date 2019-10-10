using System;
using System.Collections.Generic;
using System.IO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
//using LoteriaFacil.Application.EventSourcedNormalizers;
using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Application.ViewModels;
using LoteriaFacil.Domain.Commands;
using LoteriaFacil.Domain.Core.Bus;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Domain.Models;
using LoteriaFacil.Infra.CrossCutting.Util;
using LoteriaFacil.Infra.Data.Repository.EventSourcing;

namespace LoteriaFacil.Application.Services
{
    public class LotteryAppService : ILotteryAppService
    {

        private readonly IMapper _mapper;
        private readonly ILotteryRepository _lotteryRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public LotteryAppService(IMapper mapper,
                                 ILotteryRepository lotteryRepository,
                                 IMediatorHandler bus,
                                 IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _lotteryRepository = lotteryRepository;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<LotteryViewModel> GetAll()
        {
            return _lotteryRepository.GetAll().ProjectTo<LotteryViewModel>(_mapper.ConfigurationProvider);
        }

        public LotteryViewModel GetById(Guid id)
        {
            return _mapper.Map<LotteryViewModel>(_lotteryRepository.GetById(id));
        }

        public void Register(LotteryViewModel lotteryViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewLotteryCommand>(lotteryViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Register(List<LotteryViewModel> listlotteryViewModel)
        {
            if (listlotteryViewModel != null && listlotteryViewModel.Count > 0)
                foreach (var lotteryViewModel in listlotteryViewModel)
                {
                    var registerCommand = _mapper.Map<RegisterNewLotteryCommand>(lotteryViewModel);
                    Bus.SendCommand(registerCommand);
                }
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveLotteryCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(LotteryViewModel lotteryViewModel)
        {
            var updateCommand = _mapper.Map<UpdateLotteryCommand>(lotteryViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
