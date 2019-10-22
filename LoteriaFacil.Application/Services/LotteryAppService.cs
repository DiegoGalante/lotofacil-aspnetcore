using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<LotteryViewModel>> GetAll()
        {
            return await Task.Run(() => _lotteryRepository.GetAll().ProjectTo<LotteryViewModel>(_mapper.ConfigurationProvider));
        }

        public async Task<LotteryViewModel> GetById(Guid id)
        {
            return await Task.Run(() => _mapper.Map<LotteryViewModel>(_lotteryRepository.GetById(id)));
        }

        public async Task Register(LotteryViewModel lotteryViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewLotteryCommand>(lotteryViewModel);
            await Bus.SendCommand(registerCommand);
        }

        public void Register(List<LotteryViewModel> listlotteryViewModel)
        {
            if (listlotteryViewModel != null && listlotteryViewModel.Count > 0)
                Parallel.ForEach(listlotteryViewModel, (lotteryViewModel) =>
                 {
                     var registerCommand = _mapper.Map<RegisterNewLotteryCommand>(lotteryViewModel);
                     Bus.SendCommand(registerCommand);
                 });
        }

        public async Task Remove(Guid id)
        {
            var removeCommand = new RemoveLotteryCommand(id);
            await Bus.SendCommand(removeCommand);
        }

        public async Task Update(LotteryViewModel lotteryViewModel)
        {
            var updateCommand = _mapper.Map<UpdateLotteryCommand>(lotteryViewModel);
            await Bus.SendCommand(updateCommand);
        }
    }
}
