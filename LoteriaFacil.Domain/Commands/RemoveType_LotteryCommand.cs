using LoteriaFacil.Domain.Validations;
using System;

namespace LoteriaFacil.Domain.Commands
{
    public class RemoveType_LotteryCommand : Type_LotteryCommand
    {
        public RemoveType_LotteryCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveType_LotteryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
