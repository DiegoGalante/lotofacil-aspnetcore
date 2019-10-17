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

        //IList<PersonHistoryData> GetAllHistory(Guid id);

    }
}
