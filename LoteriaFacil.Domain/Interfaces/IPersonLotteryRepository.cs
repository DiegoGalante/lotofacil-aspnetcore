using LoteriaFacil.Domain.Models;
using System;
using System.Collections.Generic;

namespace LoteriaFacil.Domain.Interfaces
{
    public interface IPersonLotteryRepository : IRepository<PersonLottery>
    {
        PersonLottery GetByConcurse(int concurse);

        IEnumerable<PersonLottery> GetByTypeLottery(Guid TypeLotteryId, Guid personId);

    }
}
