using System;
using System.Collections.Generic;
using System.Linq;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Domain.Models;
using LoteriaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace LoteriaFacil.Infra.Data.Repository
{
    public class PersonLotteryRepository : Repository<PersonLottery>, IPersonLotteryRepository
    {
        public PersonLotteryRepository(LoteriaFacilContext context) : base(context)
        {
        }

        public PersonLottery GetByConcurse(int concurse)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Concurse == concurse);
        }

        public IEnumerable<PersonLottery> GetByTypeLottery(Guid lotteryId, Guid personId)
        {
            //return DbSet.AsNoTracking(). (c => c.Lottery.Id == lotteryId and c.Person.Id = personId);
            return null;
        }

        public string GetFunctionJogoPessoa(int concurse)
        {
            return DbSet.FromSql("SELECT dbo.JogoPessoa", concurse).ToString();
        }

        public string GetFunctionJogoPessoa(Guid personId, int concurse)
        {
            return DbSet.FromSql("SELECT dbo.JogoPessoa", concurse, personId).ToString();
        }

        public string GetFunctionJsonDashBoard(int concurse = 0)
        {
            return DbSet.FromSql("SELECT dbo.jsonDashboard", concurse).ToString();
        }
    }
}
