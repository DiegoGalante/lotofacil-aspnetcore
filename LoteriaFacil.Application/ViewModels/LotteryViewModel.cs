using LoteriaFacil.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoteriaFacil.Application.ViewModels
{
    public class LotteryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Número do concurso.
        /// </summary>
        /// 
        [Required(ErrorMessage = "The Concurso is Required")]
        [DisplayName("Concurso")]
        public int Concurse { get;  set; }

        /// <summary>
        /// Data do concurso.
        /// </summary>
        [Required(ErrorMessage = "The Data Concurso is Required")]
        [DisplayName("Data Concurso")]
        public DateTime DtConcurse { get;  set; }

        /// <summary>
        /// Dezenas do jogo.
        /// </summary>
        [MaxLength(120)]
        [Required(ErrorMessage = "The Dezenas is Required")]
        [DisplayName("Dezenas")]
        public string Game { get;  set; }

        /// <summary>
        /// Quantidades de acetos das 15 dezenas do concurso.
        /// </summary>
        [Required(ErrorMessage = "The Acertos 15 dezenas is Required")]
        [DisplayName("Acertos 15 dezenas")]
        public int Hit15 { get;  set; }
        /// <summary>
        /// Quantidades de acetos das 14 dezenas do concurso.
        /// </summary>
        [Required(ErrorMessage = "The Acertos 14 dezenas is Required")]
        [DisplayName("Acertos 14 dezenas")]
        public int Hit14 { get;  set; }
        /// <summary>
        /// Quantidades de acetos das 13 dezenas do concurso.
        /// </summary>
        [Required(ErrorMessage = "The Acertos 13 dezenas is Required")]
        [DisplayName("Acertos 13 dezenas")]
        public int Hit13 { get;  set; }
        /// <summary>
        /// Quantidades de acetos das 12 dezenas do concurso.
        /// </summary>
        [Required(ErrorMessage = "The Acertos 12 dezenas is Required")]
        [DisplayName("Acertos 12 dezenas")]
        public int Hit12 { get;  set; }
        /// <summary>
        /// Quantidades de acetos das 11 dezenas do concurso.
        /// </summary>
        [Required(ErrorMessage = "The Acertos 11 dezenas is Required")]
        [DisplayName("Acertos 11 dezenas")]
        public int Hit11 { get;  set; }

        /// <summary>
        /// Valor do rateio  das 15 dezenas.
        /// </summary>
        [Required(ErrorMessage = "The Rateio 15 dezenas is Required")]
        [DisplayName("Rateio 15 dezenas")]
        public decimal Shared15 { get;  set; }

        /// <summary>
        /// Valor do rateio  das 14 dezenas.
        /// </summary>
        [Required(ErrorMessage = "The Rateio 14 dezenas is Required")]
        [DisplayName("Rateio 14 dezenas")]
        public decimal Shared14 { get;  set; }

        /// <summary>
        /// Valor do rateio  das 13 dezenas.
        /// </summary>
        [Required(ErrorMessage = "The Rateio 13 dezenas is Required")]
        [DisplayName("Rateio 13 dezenas")]
        public decimal Shared13 { get;  set; }

        /// <summary>
        /// Valor do rateio  das 12 dezenas.
        /// </summary>
        [Required(ErrorMessage = "The Rateio 12 dezenas is Required")]
        [DisplayName("Rateio 12 dezenas")]
        public decimal Shared12 { get;  set; }

        /// <summary>
        /// Valor do rateio  das 11 dezenas.
        /// </summary>
        [Required(ErrorMessage = "The Rateio 11 dezenas is Required")]
        [DisplayName("Rateio 11 dezenas")]
        public decimal Shared11 { get;  set; }

        /// <summary>
        /// Data do próximo concurso.
        /// </summary>
        [Required(ErrorMessage = "The Data do proximo concurso is Required")]
        [DisplayName("Data do proximo concurso")]
        public DateTime DtNextConcurse { get;  set; }


        /// <summary>
        /// Tipo odo jogo ID.
        /// </summary>
        [Required(ErrorMessage = "The Tipo do Jogo ID is Required")]
        [DisplayName("Tipo do Jogo ID")]
        public TypeLottery TypeLottery { get;  set; }
    }
}
