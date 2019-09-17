using System;
using LoteriaFacil.Domain.Core.Events;

namespace LoteriaFacil.Domain.Events
{
    public class ConfigurationRegisteredEvent : Event
    {
        public ConfigurationRegisteredEvent(Guid id,
                        bool calcular_dezenas_sem_pontuacao,
                        bool enviar_email_manualmente,
                        bool enviar_email_automaticamente,
                        bool checar_jogo_online,
                        decimal valor_minimo_para_envio_email)
        {
            Id = id;
            Calcular_Dezenas_Sem_Pontuacao = calcular_dezenas_sem_pontuacao;
            Enviar_Email_Manualmente = enviar_email_manualmente;
            Enviar_Email_Automaticamente = enviar_email_automaticamente;
            Checar_Jogo_Online = checar_jogo_online;
            Valor_Minimo_Para_Envio_Email = valor_minimo_para_envio_email;
            AggregateId = id;
        }

        public Guid Id { get; set; }
        public bool Calcular_Dezenas_Sem_Pontuacao { get; set; }
        public bool Enviar_Email_Manualmente { get; set; }
        public bool Enviar_Email_Automaticamente { get; set; }
        public bool Checar_Jogo_Online { get; set; }
        public decimal Valor_Minimo_Para_Envio_Email { get; set; }
    }
}
