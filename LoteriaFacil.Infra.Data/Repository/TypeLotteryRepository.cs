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
    public class TypeLotteryRepository : Repository<TypeLottery>, ITypeLotteryRepository
    {
        public TypeLotteryRepository(LoteriaFacilContext context) : base(context)
        {

        }

        public TypeLottery GetByName(string name = "Loto Fácil")
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Name == name);
        }

    }
}
