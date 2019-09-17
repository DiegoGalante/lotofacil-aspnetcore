using LoteriaFacil.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace LoteriaFacil.Application.Interfaces
{
    public interface IConfigurationAppService : IDisposable
    {
        void Register(ConfigurationViewModel configurationViewModel);
        IEnumerable<ConfigurationViewModel> GetAll();
        ConfigurationViewModel GetById(Guid id);
        void Update(ConfigurationViewModel configurationViewModel);
        //void Remove(Guid id);
    }
}
