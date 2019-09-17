using LoteriaFacil.Domain.Models;
using System;
using System.Collections.Generic;

namespace LoteriaFacil.Domain.Interfaces
{
    public interface IPerson_LotteryRepository : IRepository<Person_Lottery>
    {
        //?
        Person_Lottery GetByConcurse(int concurse);

        IEnumerable<Person_Lottery> GetByType_Lottery(Guid type_lotteryId, Guid personId);

        string GetFunctionJogoPessoa(int concurse);

        string GetFunctionJogoPessoa(int concurse, Guid personId);
    }
}
