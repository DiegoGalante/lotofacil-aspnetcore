using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
   public class RemoveTypeLotteryCommandValidation : TypeLotteryValidation<RemoveTypeLotteryCommand>
    {
        public RemoveTypeLotteryCommandValidation()
        {
            ValidateId();
        }
    }
}
