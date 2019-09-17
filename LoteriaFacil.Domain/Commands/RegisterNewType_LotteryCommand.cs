using LoteriaFacil.Domain.Validations;

namespace LoteriaFacil.Domain.Commands
{
   public class RegisterNewType_LotteryCommand : Type_LotteryCommand
    {
        public RegisterNewType_LotteryCommand(string name, int tens_min, decimal bet_min, int hit_min, int hit_max)
        {
            this.Name = name;
            this.Tens_Min = tens_min;
            this.Bet_Min = bet_min;
            this.Hit_Min = hit_min;
            this.Hit_Max = hit_max;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewType_LotteryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
