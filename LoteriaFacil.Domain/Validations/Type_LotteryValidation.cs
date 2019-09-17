using LoteriaFacil.Domain.Commands;
using FluentValidation;
using System;

namespace LoteriaFacil.Domain.Validations
{
    public class Type_LotteryValidation<T> : AbstractValidator<T> where T : Type_LotteryCommand
    {
        //FAZER VALIDAÇÕES MELHORES

        private readonly string _frase = string.Format(" não pode ser {0}!", "#");

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);

        }

        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome" + _frase.Replace("#", "vazio"))
                .NotNull().WithMessage("Nome" + _frase.Replace("#", "nulo"))
                .Length(3, 120).WithMessage("O Nome deve ter entre 3 e 120 caracteres.");
        }

        protected void ValidateTens_Min()
        {
            RuleFor(c => c.Tens_Min)
                .NotEmpty().WithMessage("Quantidade de dezenas" + _frase.Replace("#", "vazio"))
                .NotNull().WithMessage("Quantidade de dezenas" + _frase.Replace("#", "nulo"));
        }
        protected void ValidateBet_Min()
        {
            RuleFor(c => c.Bet_Min)
                .NotEmpty().WithMessage("Valor mínimo da aposta" + _frase.Replace("#", "vazio"))
                .NotNull().WithMessage("Valor mínimo da aposta" + _frase.Replace("#", "nulo"));
        }
        protected void ValidateHit_Min()
        {
            RuleFor(c => c.Hit_Min)
                .NotEmpty().WithMessage("Acertos minimos para ganhar" + _frase.Replace("#", "vazio"))
                .NotNull().WithMessage("Acertos mínimos para ganhar" + _frase.Replace("#", "nulo"));
        }

        protected void ValidateHit_Max()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Acertos maximos para ganhar" + _frase.Replace("#", "vazio"))
                .NotNull().WithMessage("Acertos maximos para ganhar" + _frase.Replace("#", "nulo"));
        }
    }
}
