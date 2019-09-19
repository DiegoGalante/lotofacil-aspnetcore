﻿using System;
using LoteriaFacil.Domain.Models;
using LoteriaFacil.Domain.Validations;

namespace LoteriaFacil.Domain.Commands
{
    public class UpdatePersonLotteryCommand : PersonLotteryCommand
    {
        public UpdatePersonLotteryCommand(Guid id, int concurse, string game, int hits, decimal ticket_amount, DateTime? game_checked, Lottery lottery, Person person)
        {
            Id = id;
            Concurse = concurse;
            Hits = hits;
            Ticket_Amount = ticket_amount;
            Game_Checked = game_checked;
            Lottery = lottery;
            Person = person;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdatePersonLotteryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}