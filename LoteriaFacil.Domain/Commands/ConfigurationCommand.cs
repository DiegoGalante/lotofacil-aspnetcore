using LoteriaFacil.Domain.Core.Commands;
using System;

namespace LoteriaFacil.Domain.Commands
{
    public abstract class ConfigurationCommand : Command
    {
        public Guid Id { get; protected set; }
        public bool Calcular_Dezenas_Sem_Pontuacao { get; protected set; }
        public bool Enviar_Email_Manualmente { get; protected set; }
        public bool Enviar_Email_Automaticamente { get; protected set; }
        public bool Checar_Jogo_Online { get; protected set; }
        public decimal Valor_Minimo_Para_Envio_Email { get; protected set; }
    }
}
