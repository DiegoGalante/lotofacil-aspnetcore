using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoteriaFacil.Application.ViewModels
{
    public class Type_LotteryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do jogo. Exemplo: Loto Fácil, Mega Sena.
        /// </summary>
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(120)]
        [DisplayName("Nome")]
        public string Name { get; set; }


        /// <summary>
        /// Quantidade de Dezenas mínimas.
        /// </summary>
        [DisplayName("Aposta Mínima")]
        public int Tens_Min { get; set; }

        /// <summary>
        /// Valor da aposta mínima.
        /// </summary>
        [DisplayName("Valor da Aposta")]
        public decimal Bet_Min { get; set; }

        /// <summary>
        /// Quantidade mínima das dezenas que se pode ganhar.
        /// </summary>
        [DisplayName("Quantidade mínima de acertos")]
        public int Hit_Min { get; set; }

        /// <summary>
        /// Quantidade maxima das dezenas que se pode ganhar.
        /// </summary>
        [DisplayName("Quantidade máxima de acertos")]
        public int Hit_Max { get; set; }

    }
}
