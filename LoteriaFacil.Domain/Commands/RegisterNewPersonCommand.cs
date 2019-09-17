using LoteriaFacil.Domain.Validations;
using System;

namespace LoteriaFacil.Domain.Commands
{
    public class RegisterNewPersonCommand : PersonCommand
    {
        public RegisterNewPersonCommand(string name, string email, string password, DateTime dtregister, bool active)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.DtRegister = dtregister;
            this.Active = active;
        }


        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPersonCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
