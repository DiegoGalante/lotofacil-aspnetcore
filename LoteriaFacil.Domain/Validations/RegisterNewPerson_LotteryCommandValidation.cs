using LoteriaFacil.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Domain.Validations
{
    public class RegisterNewPerson_LotteryCommandValidation : Person_LotteryValidation<RegisterNewPerson_LotteryCommand>
    {
        public RegisterNewPerson_LotteryCommandValidation()
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
