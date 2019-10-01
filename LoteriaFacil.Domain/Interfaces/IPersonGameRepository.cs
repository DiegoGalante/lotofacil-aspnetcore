using LoteriaFacil.Domain.Models;
using System;
using System.Collections.Generic;

namespace LoteriaFacil.Domain.Interfaces
{
    public interface IPersonGameRepository : IRepository<PersonGame>
    {
        IEnumerable<PersonGame> GetFunctionJogoPessoa(Guid personId, int concurse);
        IEnumerable<PersonGame> GetFunctionJogosConcurso(int concurse);
    }
}
