using LoteriaFacil.Domain.Commands;
using FluentValidation;
using System;

namespace LoteriaFacil.Domain.Validations
{
    public abstract class LotteryValidation<T> : AbstractValidator<T> where T : LotteryCommand
    {
        private readonly string _frase = string.Format(" não pode ser {0}!", "#");

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);

        }

        //protected void ValidateType_LotteryId()
        //{
        //    RuleFor(c => c.Type_LotteryId)
        //        .NotNull()
        //        .NotEqual(0);
        //}

        protected void ValidateType_LotteryId()
        {
            RuleFor(c => c.Type_Lottery.Id)
                .NotEqual(Guid.Empty);
        }

        //protected void ValidateType_LotteryId()
        //{
        //    RuleFor(c => c.Type_LotteryId)
        //        .NotEqual(Guid.Empty);
        //}

        protected void ValidateConcurse()
        {
            RuleFor(c => c.Concurse)
                .NotEqual(0).WithMessage("Concurso não poder igual a 0")
                .NotEmpty().WithMessage("Consurso" + _frase.Replace("#", "vazio"))
                .NotNull().WithMessage("Consurso" + _frase.Replace("#", "nulo"));
        }

        protected void ValidateGame()
        {
            RuleFor(c => c.Game)
                .NotEmpty().WithMessage("Jogo" + _frase.Replace("#", "vazio"))
                .NotNull().WithMessage("Jogo" + _frase.Replace("#", "nulo"))
                .Length(0, 200).WithMessage("O Jogo deve ser entre 0 e 200 caracteres!");
        }

        protected void ValidateDtConcurse()
        {

        }

        protected void ValidateHit15()
        {

        }

        protected void ValidateHit14()
        {

        }

        protected void ValidateHit13()
        {

        }

        protected void ValidateHit12()
        {

        }

        protected void ValidateHit11()
        {

        }


        protected void ValidateShared15()
        {

        }

        protected void ValidateShared14()
        {

        }

        protected void ValidateShared13()
        {

        }

        protected void ValidateShared12()
        {

        }

        protected void ValidateShared11()
        {

        }

        protected void ValidateDtNextConcurse()
        {

        }
    }
}
