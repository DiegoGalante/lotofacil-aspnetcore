using LoteriaFacil.Domain.Models;
using System;

namespace LoteriaFacil.Domain.Interfaces
{
    public interface IConfigurationRepository : IRepository<Configuration>
    {
        Configuration GetConfigurationById(Guid id);
    }
}
