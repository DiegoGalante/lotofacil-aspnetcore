using System;
using System.Collections.Generic;
//using LoteriaFacil.Application.EventSourcedNormalizers;
using LoteriaFacil.Application.ViewModels;

namespace LoteriaFacil.Application.Interfaces
{
    public interface IPerson_LotteryAppService : IDisposable
    {
        void Register(Person_LotteryViewModel customerViewModel);
        IEnumerable<Person_LotteryViewModel> GetAll();
        Person_LotteryViewModel GetById(Guid id);
        void Update(Person_LotteryViewModel customerViewModel);
        void Remove(Guid id);
        //IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
