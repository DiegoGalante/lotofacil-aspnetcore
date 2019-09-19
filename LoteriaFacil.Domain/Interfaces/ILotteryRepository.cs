using LoteriaFacil.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Domain.Interfaces 
{
    public interface ILotteryRepository : IRepository<Lottery>
    {
        //Lottery GetByTypeLotteryId(int TypeLotteryId);

        Lottery GetByTypeLotteryId(Guid TypeLotteryId);

        string GetFunctionJsonDashboard(int concurse);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lotteryId"></param>
        /// <param name="concurse"></param>
        /// <param name="dtConcurse">
        /// Formato da data yyyy/mm/dd.
        /// </param>
        /// <param name="game"></param>
        /// <param name="hit15"></param>
        /// <param name="hit11"></param>
        /// <param name="hit11"></param>
        /// <param name="hit11"></param>
        /// <param name="hit11"></param>
        /// <param name="shared15"></param>
        /// <param name="shared14"></param>
        /// <param name="shared13"></param>
        /// <param name="shared12"></param>
        /// <param name="shared11"></param>
        /// <param name="dtNextConcurse">
        /// Formato da data yyyy/mm/dd.
        /// </param>
        /// <param name="TypeLotteryId"></param>
        void SetProcedureSP_SAVE_GAME(Guid lotteryId, int concurse, string dtConcurse, string game
                                        , int hit15, int hit14, int hit13, int hit12, int hit11
                                        , decimal shared15, decimal shared14, decimal shared13, decimal shared12, decimal shared11
                                        , string dtNextConcurse, Guid TypeLotteryId);

        void SetProcedureSP_CHECK_GAME(int concurse, Guid TypeLotteryId, Guid personId);
    }
}
