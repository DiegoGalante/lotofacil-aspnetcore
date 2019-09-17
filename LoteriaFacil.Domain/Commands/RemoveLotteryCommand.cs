using LoteriaFacil.Domain.Validations;
using System;

namespace LoteriaFacil.Domain.Commands
{
    public class RemoveLotteryCommand : LotteryCommand
    {
        public RemoveLotteryCommand(Guid id)
        {
            Id = id;
            AggregateId = id;

        }
        public override bool IsValid()
        {
            ValidationResult = new RemoveLotteryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
