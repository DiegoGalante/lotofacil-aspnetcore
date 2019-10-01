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

        public IEnumerable<PersonGame> GetFunctionJogoPessoa(Guid personId, int concurse, bool calculateTensWithoutHits = false)
        {
            if (calculateTensWithoutHits)
                return DbSet.FromSql($"SELECT * from dbo.JogoPessoa({concurse}, {personId})").ToList().OrderBy(c => c.Hits);
            else
                return DbSet.FromSql($"SELECT * from dbo.JogoPessoa({concurse}, {personId})").ToList().Where(c => c.Hits > 10).OrderBy(c => c.Hits);
        }

        public IEnumerable<PersonGame> GetFunctionJogosConcurso(int concurse, bool calculateTensWithoutHits = false)
        {
            if (calculateTensWithoutHits)
                return DbSet.FromSql($"SELECT * from dbo.JogosConcurso({concurse})").ToList().OrderByDescending(c => c.Hits);
            else
                return DbSet.FromSql($"SELECT * from dbo.JogosConcurso({concurse})").ToList().Where(c => c.Hits > 10).OrderByDescending(c => c.Hits);
        }


    }
}
