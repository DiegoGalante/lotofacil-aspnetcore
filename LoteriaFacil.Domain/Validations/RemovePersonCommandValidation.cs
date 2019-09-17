using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
    public class RemovePersonCommandValidation : PersonValidation<RemovePersonCommand>
    {
        public RemovePersonCommandValidation()
        {
            ValidateId();
        }
    }
}
