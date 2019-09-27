using System;
using System.Collections.Generic;
using System.Linq;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Domain.Models;
using LoteriaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoteriaFacil.Infra.Data.Repository
{
    public class PersonGameRepository : Repository<PersonGame>, IPersonGameRepository
    {
        public PersonGameRepository(LoteriaFacilContext context) : base(context)
        {
        }

        public IEnumerable<PersonGame> GetFunctionJogoPessoa(Guid personId, int concurse)
        {
            return DbSet.FromSql($"SELECT * from dbo.JogoPessoa({concurse}, {personId})").ToList();
        }

        public IEnumerable<PersonGame> GetFunctionJogoPessoa(int concurse)
        {
            return DbSet.FromSql($"SELECT * from dbo.JogoPessoa({concurse})").ToList();
        }


    }
}
