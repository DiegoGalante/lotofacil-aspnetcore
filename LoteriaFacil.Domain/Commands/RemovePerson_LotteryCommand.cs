using System;
using LoteriaFacil.Domain.Validations;


namespace LoteriaFacil.Domain.Commands
{
    public class RemovePerson_LotteryCommand : Person_LotteryCommand
    {
        public RemovePerson_LotteryCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemovePerson_LotteryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
