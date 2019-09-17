using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
    public class RemoveLotteryCommandValidation : LotteryValidation<RemoveLotteryCommand>
    {
        public RemoveLotteryCommandValidation()
        {
            ValidateId();
        }
    }
}
