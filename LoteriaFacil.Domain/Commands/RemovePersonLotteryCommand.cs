using System;
using LoteriaFacil.Domain.Validations;


namespace LoteriaFacil.Domain.Commands
{
    public class RemovePersonLotteryCommand : PersonLotteryCommand
    {
        public RemovePersonLotteryCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemovePersonLotteryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
