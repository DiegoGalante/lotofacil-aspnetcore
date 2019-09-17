using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Domain.Models;
using LoteriaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoteriaFacil.Infra.Data.Repository
{
    public class Type_LotteryRepository : Repository<Type_Lottery>, IType_LotteryRepository
    {
        public Type_LotteryRepository(LoteriaFacilContext context) : base(context)
        {

        }

        public Type_Lottery GetByName(string name = "Loto Fácil")
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }

    }
}
