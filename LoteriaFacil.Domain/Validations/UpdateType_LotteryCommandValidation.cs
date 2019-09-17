using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
    public class UpdateType_LotteryCommandValidation : Type_LotteryValidation<UpdateType_LotteryCommand>
    {
        public UpdateType_LotteryCommandValidation()
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
