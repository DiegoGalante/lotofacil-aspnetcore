using LoteriaFacil.Domain.Core.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoteriaFacil.Domain.Models
{
    public class Lottery : Entity
    {
        public Lottery(Guid id, int concurse, DateTime dtconcurse, string game, int hit15, int hit14, int hit13, int hit12, int hit11, decimal shared15, decimal shared14, decimal shared13, decimal shared12, decimal shared11, DateTime dtnextconcurse, TypeLottery TypeLottery)
        {
            this.Id = id;
            this.Concurse = concurse;
            this.DtConcurse = dtconcurse;
            this.Game = game;
            this.Hit15 = hit15;
            this.Hit14 = hit14;
            this.Hit13 = hit13;
            this.Hit12 = hit12;
            this.Hit11 = hit11;
            this.Shared15 = shared15;
            this.Shared14 = shared14;
            this.Shared13 = shared13;
            this.Shared12 = shared12;
            this.Shared11 = shared11;
            this.DtNextConcurse = dtnextconcurse;
            this.TypeLottery = TypeLottery;
        }

        public Lottery(Guid id, int concurse, DateTime dtconcurse, string game, int hit15, int hit14, int hit13, int hit12, int hit11, decimal shared15, decimal shared14, decimal shared13, decimal shared12, decimal shared11, DateTime dtnextconcurse, Guid typeLotteryId)
        {
            this.Id = id;
            this.Concurse = concurse;
            this.DtConcurse = dtconcurse;
            this.Game = game;
            this.Hit15 = hit15;
            this.Hit14 = hit14;
            this.Hit13 = hit13;
            this.Hit12 = hit12;
            this.Hit11 = hit11;
            this.Shared15 = shared15;
            this.Shared14 = shared14;
            this.Shared13 = shared13;
            this.Shared12 = shared12;
            this.Shared11 = shared11;
            this.DtNextConcurse = dtnextconcurse;
            this.TypeLotteryId = typeLotteryId;
        }

        public Lottery()
        {

        }

        /// <summary>
        /// Número do concurso.
        /// </summary>
        public int Concurse { get;  set; }

        /// <summary>
        /// Data do concurso.
        /// </summary>
        public DateTime DtConcurse { get;  set; }

        /// <summary>
        /// Dezenas do jogo.
        /// </summary>
        public string Game { get;  set; }

        /// <summary>
        /// Quantidades de acetos das 15 dezenas do concurso.
        /// </summary>
        public int Hit15 { get;  set; }
        /// <summary>
        /// Quantidades de acetos das 14 dezenas do concurso.
        /// </summary>
        public int Hit14 { get;  set; }
        /// <summary>
        /// Quantidades de acetos das 13 dezenas do concurso.
        /// </summary>
        public int Hit13 { get;  set; }
        /// <summary>
        /// Quantidades de acetos das 12 dezenas do concurso.
        /// </summary>
        public int Hit12 { get;  set; }
        /// <summary>
        /// Quantidades de acetos das 11 dezenas do concurso.
        /// </summary>
        public int Hit11 { get;  set; }

        /// <summary>
        /// Valor do rateio  das 15 dezenas.
        /// </summary>
        public decimal Shared15 { get;  set; }

        /// <summary>
        /// Valor do rateio  das 14 dezenas.
        /// </summary>
        public decimal Shared14 { get;  set; }

        /// <summary>
        /// Valor do rateio  das 13 dezenas.
        /// </summary>
        public decimal Shared13 { get;  set; }

        /// <summary>
        /// Valor do rateio  das 12 dezenas.
        /// </summary>
        public decimal Shared12 { get;  set; }

        /// <summary>
        /// Valor do rateio  das 11 dezenas.
        /// </summary>
        public decimal Shared11 { get;  set; }

        /// <summary>
        /// Data do próximo concurso.
        /// </summary>
        public DateTime DtNextConcurse { get;  set; }

        /// <summary>
        /// Tipo odo jogo ID.
        /// </summary>
        public TypeLottery TypeLottery { get;  set; }

        public Guid TypeLotteryId { get;  set; }
    }
}

