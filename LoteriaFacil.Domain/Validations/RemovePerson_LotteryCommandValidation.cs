using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
    public class RemovePerson_LotteryCommandValidation : Person_LotteryValidation<RemovePerson_LotteryCommand>
    {
        public RemovePerson_LotteryCommandValidation()
        {
            ValidateId();
        }
    }
}
