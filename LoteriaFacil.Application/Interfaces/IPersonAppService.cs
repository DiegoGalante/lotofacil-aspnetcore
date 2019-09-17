using LoteriaFacil.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace LoteriaFacil.Application.Interfaces
{
    public interface IPersonAppService : IDisposable
    {
        void Register(PersonViewModel personViewModel);
        IEnumerable<PersonViewModel> GetAll();
        PersonViewModel GetById(Guid id);
        void Update(PersonViewModel personViewModel);
        void Remove(Guid id);
        //IList<PersonHistoryData> GetAllHistory(Guid id);

    }
}
