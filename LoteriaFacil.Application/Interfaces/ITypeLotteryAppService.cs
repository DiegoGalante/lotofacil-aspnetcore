using LoteriaFacil.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace LoteriaFacil.Application.Interfaces
{
    public interface ITypeLotteryAppService : IDisposable
    {
        void Register(TypeLotteryViewModel TypeLotteryViewModel);
        IEnumerable<TypeLotteryViewModel> GetAll();
        TypeLotteryViewModel GetById(Guid id);

        TypeLotteryViewModel GetByName(string name = "Loto Fácil");
        void Update(TypeLotteryViewModel TypeLotteryViewModel);
        void Remove(Guid id);
    }
}
