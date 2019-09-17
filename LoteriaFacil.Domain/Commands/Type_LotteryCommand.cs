using LoteriaFacil.Domain.Core.Commands;
using System;

namespace LoteriaFacil.Domain.Commands
{
    public abstract class Type_LotteryCommand : Command
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        /// <summary>
        /// Quantidade de Dezenas mínimas.
        /// </summary>
        public int Tens_Min { get; set; }
        /// <summary>
        /// Valor da aposta mínima.
        /// </summary>
        public decimal Bet_Min { get; set; }

        /// <summary>
        /// Quantidade mínima das dezenas que se pode ganhar.
        /// </summary>
        public int Hit_Min { get; set; }

        /// <summary>
        /// Quantidade maxima das dezenas que se pode ganhar.
        /// </summary>
        public int Hit_Max { get; set; }
    }
}
