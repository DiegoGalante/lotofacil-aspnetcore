using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LoteriaFacil.Domain.Core.Models;
using LoteriaFacil.Domain.Models;

namespace LoteriaFacil.Application.ViewModels
{
    public class Person_LotteryViewModel : Entity
    {
        [Key]
        public Guid Id { get; set; }

        public Lottery Lottery { get; private set; }
        public Person Person { get; private set; }

        [DisplayName("Concurso")]
        public int Concurse { get; private set; }

        /// <summary>
        /// Dezenas do jogo.
        /// </summary>
        [MinLength(1)]
        [MaxLength(100)]
        [DisplayName("Dezenas")]
        public string Game { get; private set; }

        /// <summary>
        /// Quantidade de acertos.
        /// </summary>
        [DisplayName("Acertos")]
        public int Hits { get; private set; }

        /// <summary>
        /// Valor R$ a receber do bilhete.
        /// </summary>
        [DisplayName("Valor do Bilhete")]
        public decimal Ticket_Amount { get; private set; }

        /// <summary>
        /// Jogo checado.
        /// </summary>
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Jogo Checado em")]
        public DateTime? Game_Checked { get; private set; }

        /// <summary>
        /// Data do registro do jogo.
        /// </summary>
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Jogo Registrado em")]
        public DateTime Game_Register { get; private set; }
    }
}
