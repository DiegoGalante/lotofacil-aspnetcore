using LoteriaFacil.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Domain.Validations
{
    public class RegisterNewPersonLotteryCommandValidation : PersonLotteryValidation<RegisterNewPersonLotteryCommand>
    {
        public RegisterNewPersonLotteryCommandValidation()
        {
            ValidateLottery();
            ValidatePerson();
            ValidateConcurse();
            ValidateGame();
            ValidateHits();
            ValidateGame_Checked();
            ValidateGame_Register();
            ValidateTicket_Amount();
        }
    }
}
