﻿using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
    public class RegisterNewLotteryCommandValidation : LotteryValidation<RegisterNewLotteryCommand>
    {
        public RegisterNewLotteryCommandValidation()
        {
            ValidateConcurse();
            ValidateDtConcurse();
            ValidateGame();
            ValidateHit15();
            ValidateHit14();
            ValidateHit13();
            ValidateHit12();
            ValidateHit11();
            ValidateShared15();
            ValidateShared14();
            ValidateShared13();
            ValidateShared12();
            ValidateShared11();
            ValidateTypeLotteryId();
            ValidateDtNextConcurse();
        }
    }
}