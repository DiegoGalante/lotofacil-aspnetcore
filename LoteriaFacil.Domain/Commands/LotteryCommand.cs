using LoteriaFacil.Domain.Core.Commands;
using LoteriaFacil.Domain.Models;
using System;

namespace LoteriaFacil.Domain.Commands
{
    public abstract class LotteryCommand : Command
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Número do concurso.
        /// </summary>
        public int Concurse { get; protected set; }

        /// <summary>
        /// Data do concurso.
        /// </summary>
        public DateTime DtConcurse { get; protected set; }

        /// <summary>
        /// Dezenas do jogo.
        /// </summary>
        public string Game { get; protected set; }

        /// <summary>
        /// Quantidades de acetos das 15 dezenas do concurso.
        /// </summary>
        public int Hit15 { get; protected set; }
        /// <summary>
        /// Quantidades de acetos das 14 dezenas do concurso.
        /// </summary>
        public int Hit14 { get; protected set; }
        /// <summary>
        /// Quantidades de acetos das 13 dezenas do concurso.
        /// </summary>
        public int Hit13 { get; protected set; }
        /// <summary>
        /// Quantidades de acetos das 12 dezenas do concurso.
        /// </summary>
        public int Hit12 { get; protected set; }
        /// <summary>
        /// Quantidades de acetos das 11 dezenas do concurso.
        /// </summary>
        public int Hit11 { get; protected set; }

        /// <summary>
        /// Valor do rateio  das 15 dezenas.
        /// </summary>
        public decimal Shared15 { get; protected set; }

        /// <summary>
        /// Valor do rateio  das 14 dezenas.
        /// </summary>
        public decimal Shared14 { get; protected set; }

        /// <summary>
        /// Valor do rateio  das 13 dezenas.
        /// </summary>
        public decimal Shared13 { get; protected set; }

        /// <summary>
        /// Valor do rateio  das 12 dezenas.
        /// </summary>
        public decimal Shared12 { get; protected set; }

        /// <summary>
        /// Valor do rateio  das 11 dezenas.
        /// </summary>
        public decimal Shared11 { get; protected set; }

        /// <summary>
        /// Data do próximo concurso.
        /// </summary>
        public DateTime DtNextConcurse { get; protected set; }

        /// <summary>
        /// Tipo odo jogo ID.
        /// </summary>
        public Type_Lottery Type_Lottery { get; protected set; }
    }
}
