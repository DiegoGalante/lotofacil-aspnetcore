using System;
using System.Linq;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Domain.Models;
using LoteriaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoteriaFacil.Infra.Data.Repository
{
    public class ConfigurationRepository : Repository<Configuration>, IConfigurationRepository
    {

        public ConfigurationRepository(LoteriaFacilContext context) : base(context)
        {

        }

        public Configuration GetConfigurationById(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }
    }
}
