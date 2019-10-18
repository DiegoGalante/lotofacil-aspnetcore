using LoteriaFacil.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoteriaFacil.Application.Interfaces
{
    public interface IConfigurationAppService : IDisposable
    {
        Task Register(ConfigurationViewModel configurationViewModel);

        Task<IEnumerable<ConfigurationViewModel>> GetAll();

        Task<ConfigurationViewModel> GetById(Guid id);
        Task Update(ConfigurationViewModel configurationViewModel);
        //void Remove(Guid id);
    }
}
