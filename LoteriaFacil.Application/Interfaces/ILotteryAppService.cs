using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using LoteriaFacil.Application.EventSourcedNormalizers;
using LoteriaFacil.Application.ViewModels;

namespace LoteriaFacil.Application.Interfaces
{
    public interface ILotteryAppService : IDisposable
    {
        Task Register(LotteryViewModel lotteryViewModel);
        Task<IEnumerable<LotteryViewModel>> GetAll();
        Task<LotteryViewModel> GetById(Guid id);
        Task Update(LotteryViewModel lotteryViewModel);
        Task Remove(Guid id);
    }
}
