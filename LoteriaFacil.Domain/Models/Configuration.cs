using LoteriaFacil.Domain.Core.Models;
using System;

namespace LoteriaFacil.Domain.Models
{
    public class Configuration : Entity
    {

        public Configuration(Guid id,
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
            //this.PesId = pesId;
        }

        public Configuration() { }

        public bool Calcular_Dezenas_Sem_Pontuacao { get; set; }
        public bool Enviar_Email_Manualmente { get; set; }
        public bool Enviar_Email_Automaticamente { get; set; }
        public bool Checar_Jogo_Online { get; set; }
        public decimal Valor_Minimo_Para_Envio_Email { get; set; }

        //public Guid PesId { get; protected set; }
    }
}

