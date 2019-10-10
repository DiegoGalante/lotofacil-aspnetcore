using System;
using System.Collections.Generic;
//using LoteriaFacil.Application.EventSourcedNormalizers;
using LoteriaFacil.Application.ViewModels;

namespace LoteriaFacil.Application.Interfaces
{
    public interface ILotteryAppService : IDisposable
    {
        void Register(LotteryViewModel lotteryViewModel);
        IEnumerable<LotteryViewModel> GetAll();
        LotteryViewModel GetById(Guid id);
        void Update(LotteryViewModel lotteryViewModel);
        void Remove(Guid id);
    }
}
