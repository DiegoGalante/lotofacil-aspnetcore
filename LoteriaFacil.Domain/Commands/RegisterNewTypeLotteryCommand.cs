using LoteriaFacil.Domain.Validations;

namespace LoteriaFacil.Domain.Commands
{
   public class RegisterNewTypeLotteryCommand : TypeLotteryCommand
    {
        public RegisterNewTypeLotteryCommand(string name, int tens_min, decimal bet_min, int hit_min, int hit_max)
        {
            this.Name = name;
            this.Tens_Min = tens_min;
            this.Bet_Min = bet_min;
            this.Hit_Min = hit_min;
            this.Hit_Max = hit_max;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewTypeLotteryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
