using LoteriaFacil.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Domain.Validations
{
    public abstract class ConfigurationValidation<T> : AbstractValidator<T> where T : ConfigurationCommand
    {
        private readonly string _fraseVazio = string.Format("A Configuração {0} não pode ser vazio!", "#");
        private readonly string _fraseNulo = string.Format("A Configuração {0} não pode ser nulo!", "#");

        protected void ValidateCalcular_Dezenas_Sem_Pontuacao()
        {
            RuleFor(c => c.Calcular_Dezenas_Sem_Pontuacao)
                .NotEmpty().WithMessage(_fraseVazio.Replace("#", "Calcular Dezenas Sem Pontuação"))
                .NotNull().WithMessage(_fraseNulo.Replace("#", "Calcular Dezenas Sem Pontuação"));
        }

        protected void ValidateEnviar_Email_Manualmente()
        {
            RuleFor(c => c.Enviar_Email_Manualmente)
                .NotEmpty().WithMessage(_fraseVazio.Replace("#", "Enviar E-mail Manualmente"))
                .NotNull().WithMessage(_fraseNulo.Replace("#", "Enviar E-mail Manualmente"));
        }

        protected void ValidateEnviar_Email_Automaticamente()
        {
            RuleFor(c => c.Enviar_Email_Automaticamente)
                .NotEmpty().WithMessage(_fraseVazio.Replace("#", "Enviar E-mail Automaticamente"))
                .NotNull().WithMessage(_fraseNulo.Replace("#", "Enviar E-mail Automaticamente"));
        }

        protected void ValidateChecar_Jogo_Online()
        {
            RuleFor(c => c.Checar_Jogo_Online)
                .NotEmpty().WithMessage(_fraseVazio.Replace("#", "Checar Jogo Online"))
                .NotNull().WithMessage(_fraseNulo.Replace("#", "Checar Jogo Online"));
        }

        protected void ValidateValor_Minimo_Para_Envio_Email()
        {
            RuleFor(c => c.Valor_Minimo_Para_Envio_Email)
                .NotEmpty().WithMessage(_fraseVazio.Replace("#", "Valor Mínimo Para Envio do E-mail"))
                .NotNull().WithMessage(_fraseNulo.Replace("#", "Valor Mínimo Para Envio do E-mail"));
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        //protected static bool IsBoolean(object obj)
        //{
        //    if (obj.GetType().ReflectedType.IsValueType == bool)
        //        return true;
        //    else
        //        return false;
        //}
    }
}
