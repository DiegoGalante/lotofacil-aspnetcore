using LoteriaFacil.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Domain.Commands
{
    public class RemovePersonCommand : PersonCommand
    {
        public RemovePersonCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemovePersonCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
