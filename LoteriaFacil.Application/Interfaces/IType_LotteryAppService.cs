using LoteriaFacil.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace LoteriaFacil.Application.Interfaces
{
    public interface IType_LotteryAppService : IDisposable
    {
        void Register(Type_LotteryViewModel type_LotteryViewModel);
        IEnumerable<Type_LotteryViewModel> GetAll();
        Type_LotteryViewModel GetById(Guid id);

        Type_LotteryViewModel GetByName(string name = "Loto Fácil");
        void Update(Type_LotteryViewModel type_LotteryViewModel);
        void Remove(Guid id);
    }
}
