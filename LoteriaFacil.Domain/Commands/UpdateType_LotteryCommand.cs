using LoteriaFacil.Domain.Validations;
using System;

namespace LoteriaFacil.Domain.Commands
{
    public class UpdateType_LotteryCommand : Type_LotteryCommand
    {
        public UpdateType_LotteryCommand(Guid id, string name, int tens_min, decimal bet_min, int hit_min, int hit_max)
        {
            this.Id = id;
            this.Name = name;
            this.Tens_Min = tens_min;
            this.Bet_Min = bet_min;
            this.Hit_Min = hit_min;
            this.Hit_Max = hit_max;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateType_LotteryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
