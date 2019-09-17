using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoteriaFacil.Application.ViewModels
{
    public class ConfigurationViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Calcular Dezenas Sem Pontuação é um campo obrigatório!")]
        [DisplayName("Calcular Dezenas Sem Pontuação")]
        public bool Calcular_Dezenas_Sem_Pontuacao { get; set; }

        [Required(ErrorMessage = "Enviar E-mail Manualmente é um campo obrigatório!")]
        [DisplayName("Enviar E-mail Manualmente")]
        public bool Enviar_Email_Manualmente { get; set; }

        [Required(ErrorMessage = "Enviar E-mail Automaticamente é um campo obrigatório!")]
        [DisplayName("Enviar E-mail Automaticamente")]
        public bool Enviar_Email_Automaticamente { get; set; }

        [Required(ErrorMessage = "Checar Jogo Online é um campo obrigatório!")]
        [DisplayName("Checar Jogo Online")]
        public bool Checar_Jogo_Online { get; set; }

        [Required(ErrorMessage = "Valor Minimo Para Envio Email é um campo obrigatório!")]
        [DisplayName("Valor Minimo Para Envio Email")]
        public decimal Valor_Minimo_Para_Envio_Email { get; set; }
    }
}
