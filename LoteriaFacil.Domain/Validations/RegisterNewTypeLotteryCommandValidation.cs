using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
    public class RegisterNewTypeLotteryCommandValidation : TypeLotteryValidation<RegisterNewTypeLotteryCommand>
    {
        public RegisterNewTypeLotteryCommandValidation()
        {
            ValidateName();
            ValidateTens_Min();
            ValidateBet_Min();
            ValidateHit_Min();
            ValidateHit_Max();
        }
    }
}
