using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
    public class RegisterNewType_LotteryCommandValidation : Type_LotteryValidation<RegisterNewType_LotteryCommand>
    {
        public RegisterNewType_LotteryCommandValidation()
        {
            ValidateName();
            ValidateTens_Min();
            ValidateBet_Min();
            ValidateHit_Min();
            ValidateHit_Max();
        }
    }
}
