using LoteriaFacil.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Domain.Commands
{
    public class UpdatePersonCommand : PersonCommand
    {
        public UpdatePersonCommand(Guid id, string name, string email, string password, DateTime dtregister, bool active)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
            this.DtRegister = dtregister;
            this.Active = active;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePersonCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
