using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
    public class UpdateTypeLotteryCommandValidation : TypeLotteryValidation<UpdateTypeLotteryCommand>
    {
        public UpdateTypeLotteryCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateTens_Min();
            ValidateBet_Min();
            ValidateHit_Min();
            ValidateHit_Max();
        }
    }
}
