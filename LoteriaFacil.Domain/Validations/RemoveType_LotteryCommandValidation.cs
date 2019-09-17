using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
   public class RemoveType_LotteryCommandValidation : Type_LotteryValidation<RemoveType_LotteryCommand>
    {
        public RemoveType_LotteryCommandValidation()
        {
            ValidateId();
        }
    }
}
