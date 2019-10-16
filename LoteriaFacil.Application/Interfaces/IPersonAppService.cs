using LoteriaFacil.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoteriaFacil.Application.Interfaces
{
    public interface IPersonAppService : IDisposable
    {
        Task Register(PersonViewModel personViewModel);

        Task<IEnumerable<PersonViewModel>> GetAll();
        Task<PersonViewModel> GetById(Guid id);
        Task Update(PersonViewModel personViewModel);
        Task Remove(Guid id);

        Task<IEnumerable<PersonViewModel>> GetByDemand(int start = 0, int end = 0);
        //IList<PersonHistoryData> GetAllHistory(Guid id);

    }
}
