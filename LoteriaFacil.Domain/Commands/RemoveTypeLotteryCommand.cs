using LoteriaFacil.Domain.Validations;
using System;

namespace LoteriaFacil.Domain.Commands
{
    public class RemoveTypeLotteryCommand : TypeLotteryCommand
    {
        public RemoveTypeLotteryCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveTypeLotteryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
