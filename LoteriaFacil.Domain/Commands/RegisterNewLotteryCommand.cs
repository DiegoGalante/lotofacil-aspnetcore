using System;
using LoteriaFacil.Domain.Models;
using LoteriaFacil.Domain.Validations;

namespace LoteriaFacil.Domain.Commands
{
    public class RegisterNewLotteryCommand : LotteryCommand
    {
        public RegisterNewLotteryCommand(int concurse, DateTime dtconcurse, string game, int hit15, int hit14, int hit13, int hit12, int hit11, decimal shared15, decimal shared14, decimal shared13, decimal shared12, decimal shared11, DateTime dtnextconcurse, TypeLottery typeLottery)
        {
            Concurse = concurse;
            DtConcurse = dtconcurse;
            Game = game;
            Hit15 = hit15;
            Hit14 = hit14;
            Hit13 = hit13;
            Hit12 = hit12;
            Hit11 = hit11;
            Shared15 = shared15;
            Shared14 = shared14;
            Shared13 = shared13;
            Shared12 = shared12;
            Shared11 = shared11;
            DtNextConcurse = dtnextconcurse;
            TypeLottery = typeLottery;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewLotteryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
