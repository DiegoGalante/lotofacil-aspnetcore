using LoteriaFacil.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Domain.Commands
{
    public class UpdateConfigurationCommand : ConfigurationCommand
    {
        public UpdateConfigurationCommand(Guid id,
                       bool calcular_dezenas_sem_pontuacao,
                       bool enviar_email_manualmente,
                       bool enviar_email_automaticamente,
                       bool checar_jogo_online,
                       decimal valor_minimo_para_envio_email)
        {
            this.Id = id;
            this.Calcular_Dezenas_Sem_Pontuacao = calcular_dezenas_sem_pontuacao;
            this.Enviar_Email_Manualmente = enviar_email_manualmente;
            this.Enviar_Email_Automaticamente = enviar_email_automaticamente;
            this.Checar_Jogo_Online = checar_jogo_online;
            this.Valor_Minimo_Para_Envio_Email = valor_minimo_para_envio_email;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateConfigurationCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
