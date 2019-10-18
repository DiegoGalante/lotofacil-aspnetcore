using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using LoteriaFacil.Application.EventSourcedNormalizers;
using LoteriaFacil.Application.ViewModels;

namespace LoteriaFacil.Application.Interfaces
{
    public interface IPersonLotteryAppService : IDisposable
    {
        void Register(PersonLotteryViewModel customerViewModel);
        IEnumerable<PersonLotteryViewModel> GetAll();
        PersonLotteryViewModel GetById(Guid id);
        void Update(PersonLotteryViewModel customerViewModel);
        void Remove(Guid id);

        Task<Object> GetJsonDashboard(int concurse = 0);

        Task<Object> GetPersonGame(Guid personId, int concurse = 0);
        Task<Object> GetPersonGame(int concurse = 0);

        Object SendEmail(int concurse = 0);
        //IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
