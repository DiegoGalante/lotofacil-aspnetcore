using System;
using LoteriaFacil.Domain.Commands;
using FluentValidation;

namespace LoteriaFacil.Domain.Validations
{
    public abstract class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Por favor, certifique-se que digitou o nome!")
                .Length(2, 150).WithMessage("O Nome deve ter entre 2 e 150 caracteres");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
