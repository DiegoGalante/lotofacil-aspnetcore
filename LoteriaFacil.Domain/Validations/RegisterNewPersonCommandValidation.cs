using LoteriaFacil.Domain.Commands;

namespace LoteriaFacil.Domain.Validations
{
    public class RegisterNewPersonCommandValidation : PersonValidation<RegisterNewPersonCommand>
    {
        public RegisterNewPersonCommandValidation()
        {
            //ValidateId();
            ValidateName();
            //ValidateRegisterDate();
            ValidateEmail();
            ValidateActive();
        }
    }
}
