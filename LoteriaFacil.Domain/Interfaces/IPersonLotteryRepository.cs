using LoteriaFacil.Domain.Models;
using System;
using System.Collections.Generic;

namespace LoteriaFacil.Domain.Interfaces
{
    public interface IPersonLotteryRepository : IRepository<PersonLottery>
    {
        //?
        PersonLottery GetByConcurse(int concurse);

        IEnumerable<PersonLottery> GetByTypeLottery(Guid TypeLotteryId, Guid personId);

        string GetFunctionJogoPessoa(int concurse);

        string GetFunctionJsonDashBoard(int concurse = 0);

        string GetFunctionJogoPessoa(Guid personId, int concurse);
    }
}
