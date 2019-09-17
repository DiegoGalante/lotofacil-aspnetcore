using System;
using LoteriaFacil.Domain.Core.Events;

namespace LoteriaFacil.Domain.Events
{
    public class Type_LotteryUpdatedEvent : Event
    {
        public Type_LotteryUpdatedEvent(Guid id, string name, int tens_min, decimal bet_min, int hit_min, int hit_max)
        {
            this.Id = id;
            this.Name = name;
            this.Tens_Min = tens_min;
            this.Bet_Min = bet_min;
            this.Hit_Min = hit_min;
            this.Hit_Max = hit_max;
            this.AggregateId = id;
        }

        public Guid Id { get; set; }

        /// <summary>
        /// Nome do jogo. Exemplo: Loto Fácil, Mega Sena.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Quantidade de Dezenas mínimas.
        /// </summary>
        public int Tens_Min { get; private set; }
        /// <summary>
        /// Valor da aposta mínima.
        /// </summary>
        public decimal Bet_Min { get; private set; }

        /// <summary>
        /// Quantidade mínima das dezenas que se pode ganhar.
        /// </summary>
        public int Hit_Min { get; private set; }

        /// <summary>
        /// Quantidade maxima das dezenas que se pode ganhar.
        /// </summary>
        public int Hit_Max { get; private set; }
    }
}
