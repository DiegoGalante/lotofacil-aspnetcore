using System;
using LoteriaFacil.Domain.Commands;
using FluentValidation;


namespace LoteriaFacil.Domain.Validations
{
    public class PersonLotteryValidation<T> : AbstractValidator<T> where T : PersonLotteryCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidatePerson()
        {
            RuleFor(c => c.Person.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateLottery()
        {
            RuleFor(c => c.Lottery.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateConcurse()
        {
            //FAZER VALIDACAO
        }

        protected void ValidateGame()
        {
            //FAZER VALIDACAO
        }

        protected void ValidateHits()
        {
            //FAZER VALIDACAO
        }

        protected void ValidateTicket_Amount()
        {
            //FAZER VALIDACAO
        }

        protected void ValidateGame_Checked()
        {
            //FAZER VALIDACAO
        }

        protected void ValidateGame_Register()
        {
            //FAZER VALIDACAO
        }


    }
}
