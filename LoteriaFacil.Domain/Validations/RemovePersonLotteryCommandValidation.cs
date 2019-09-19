using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
    public class RemovePersonLotteryCommandValidation : PersonLotteryValidation<RemovePersonLotteryCommand>
    {
        public RemovePersonLotteryCommandValidation()
        {
            ValidateId();
        }
    }
}
