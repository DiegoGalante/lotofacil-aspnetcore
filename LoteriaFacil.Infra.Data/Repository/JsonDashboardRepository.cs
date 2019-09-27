using System;
using System.Collections.Generic;
using System.Linq;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Domain.Models;
using LoteriaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoteriaFacil.Infra.Data.Repository
{
    public class JsonDashboardRepository : Repository<JsonDashboard>, IJsonDashboardRepository
    {
        public JsonDashboardRepository(LoteriaFacilContext context) : base(context)
        {
        }

        public JsonDashboard GetFunctionJsonDashBoard(int concurse = 0)
        {
            return DbSet.FromSql($"SELECT * from dbo.jsonDashboard({concurse})").FirstOrDefault();
        }
    }
}
