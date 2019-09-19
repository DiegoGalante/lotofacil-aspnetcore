using System;
using System.Linq;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Domain.Models;
using LoteriaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoteriaFacil.Infra.Data.Repository
{
    public class LotteryRepository : Repository<Lottery>, ILotteryRepository
    {
        public LotteryRepository(LoteriaFacilContext context) : base(context)
        {
        }

        //public Lottery GetByTypeLotteryId(int TypeLotteryId)
        //{
        //    return DbSet.AsNoTracking().FirstOrDefault(c => c.TypeLotteryId == TypeLotteryId);
        //}

        //public Lottery GetByTypeLotteryId(Guid TypeLotteryId)
        //{
        //    return DbSet.AsNoTracking().FirstOrDefault(c => c.TypeLottery.Id == TypeLotteryId);
        //}

        public Lottery GetByTypeLotteryId(Guid TypeLotteryId)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.TypeLottery.Id == TypeLotteryId);
        }

        public string GetFunctionJsonDashboard(int concurse)
        {
            return DbSet.FromSql("SELECT dbo.JsonDashboard", concurse).ToString();
        }

        public Lottery GetLast()
        {
            return DbSet.FirstOrDefault();
        }

        public void SetProcedureSP_CHECK_GAME(int concurse, Guid TypeLotteryId, Guid personId)
        {
            DbSet.FromSql("SP_SAVE_GAME {0}, {2}, {3}", concurse, TypeLotteryId, personId);
        }

        public void SetProcedureSP_SAVE_GAME(Guid lotteryId, int concurse, string dtConcurse, string game, int hit15, int hit14, int hit13, int hit12, int hit11, decimal shared15, decimal shared14, decimal shared13, decimal shared12, decimal shared11, string dtNextConcurse, Guid TypeLotteryId)
        {
            //DbSet.FromSql("SP_SAVE_GAME @lot_id, @lot_concurse, @lot_dtConcurse, @lot_game, @lot_hit15, @lot_hit14, @lot_hit13, @lot_hit12, @lot_hit11, @lot_shared15, @lot_shared14, @lot_shared13, @lot_shared12, @lot_shared11, @lot_dtNextConcurse, @tpj_id",
            //                             lotteryId, concurse, dtConcurse, game, hit15, hit14, hit13, hit12, hit11, shared15, shared14, shared13, shared12, shared11, dtNextConcurse, TypeLotteryId);

            DbSet.FromSql("SP_SAVE_GAME {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}",
                                         lotteryId, concurse, dtConcurse, game, hit15, hit14, hit13, hit12, hit11, shared15, shared14, shared13, shared12, shared11, dtNextConcurse, TypeLotteryId);


            ///throw new NotImplementedException();
        }
    }
}
