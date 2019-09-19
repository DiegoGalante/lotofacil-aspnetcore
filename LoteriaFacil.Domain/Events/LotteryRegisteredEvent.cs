using LoteriaFacil.Domain.Core.Events;
using LoteriaFacil.Domain.Models;
using System;


namespace LoteriaFacil.Domain.Events
{
    public class LotteryRegisteredEvent : Event
    {
        public LotteryRegisteredEvent(Guid id, int concurse, DateTime dtconcurse, string game, int hit15, int hit14, int hit13, int hit12, int hit11, decimal shared15, decimal shared14, decimal shared13, decimal shared12, decimal shared11, DateTime dtnextconcurse, TypeLottery TypeLottery)
        {
            Id = id;
            Concurse = concurse;
            DtConcurse = dtconcurse;
            Game = game;
            Hit15 = hit15;
            Hit14 = hit14;
            Hit13 = hit13;
            Hit12 = hit12;
            Hit11 = hit11;
            Shared15 = shared15;
            Shared14 = shared14;
            Shared13 = shared13;
            Shared12 = shared12;
            Shared11 = shared11;
            DtNextConcurse = dtnextconcurse;
            TypeLottery = TypeLottery;
            AggregateId = id;
        }

        public Guid Id { get; set; }

        /// <summary>
        /// Número do concurso.
        /// </summary>
        public int Concurse { get; private set; }

        /// <summary>
        /// Data do concurso.
        /// </summary>
        public DateTime DtConcurse { get; private set; }

        /// <summary>
        /// Dezenas do jogo.
        /// </summary>
        public string Game { get; private set; }

        /// <summary>
        /// Quantidades de acetos das 15 dezenas do concurso.
        /// </summary>
        public int Hit15 { get; private set; }
        /// <summary>
        /// Quantidades de acetos das 14 dezenas do concurso.
        /// </summary>
        public int Hit14 { get; private set; }
        /// <summary>
        /// Quantidades de acetos das 13 dezenas do concurso.
        /// </summary>
        public int Hit13 { get; private set; }
        /// <summary>
        /// Quantidades de acetos das 12 dezenas do concurso.
        /// </summary>
        public int Hit12 { get; private set; }
        /// <summary>
        /// Quantidades de acetos das 11 dezenas do concurso.
        /// </summary>
        public int Hit11 { get; private set; }

        /// <summary>
        /// Valor do rateio  das 15 dezenas.
        /// </summary>
        public decimal Shared15 { get; private set; }

        /// <summary>
        /// Valor do rateio  das 14 dezenas.
        /// </summary>
        public decimal Shared14 { get; private set; }

        /// <summary>
        /// Valor do rateio  das 13 dezenas.
        /// </summary>
        public decimal Shared13 { get; private set; }

        /// <summary>
        /// Valor do rateio  das 12 dezenas.
        /// </summary>
        public decimal Shared12 { get; private set; }

        /// <summary>
        /// Valor do rateio  das 11 dezenas.
        /// </summary>
        public decimal Shared11 { get; private set; }

        /// <summary>
        /// Data do próximo concurso.
        /// </summary>
        public DateTime DtNextConcurse { get; private set; }

        /// <summary>
        /// Tipo odo jogo ID.
        /// </summary>
        public TypeLottery TypeLottery { get; private set; }
    }
}
