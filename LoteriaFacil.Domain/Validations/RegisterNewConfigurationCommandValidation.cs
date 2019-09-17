using LoteriaFacil.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Domain.Validations
{
    public class RegisterNewConfigurationCommandValidation : ConfigurationValidation<RegisterNewConfigurationCommand>
    {
        public RegisterNewConfigurationCommandValidation()
        {
            ValidateCalcular_Dezenas_Sem_Pontuacao();
            ValidateEnviar_Email_Manualmente();
            ValidateEnviar_Email_Automaticamente();
            ValidateChecar_Jogo_Online();
            ValidateValor_Minimo_Para_Envio_Email();
        }
    }
}
