using LoteriaFacil.Domain.Core.Models;
using System;

namespace LoteriaFacil.Domain.Models
{
    public class Type_Lottery : Entity
    {
        public Type_Lottery(Guid id, string name, int tens_min, decimal bet_min, int hit_min, int hit_max)
        {
            this.Id = id;
            this.Name = name;
            this.Tens_Min = tens_min;
            this.Bet_Min = bet_min;
            this.Hit_Min = hit_min;
            this.Hit_Max = hit_max;
        }

        public Type_Lottery()
        {

        }

        /// <summary>
        /// Nome do jogo. Exemplo: Loto Fácil, Mega Sena.
        /// </summary>
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
