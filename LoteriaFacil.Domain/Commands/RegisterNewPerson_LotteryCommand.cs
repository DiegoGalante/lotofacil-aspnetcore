﻿using LoteriaFacil.Domain.Models;
using LoteriaFacil.Domain.Validations;
using System;

namespace LoteriaFacil.Domain.Commands
{
    public class RegisterNewPerson_LotteryCommand : Person_LotteryCommand
    {
        public RegisterNewPerson_LotteryCommand(int concurse, string game, int hits, decimal ticket_amount, DateTime? game_checked, DateTime game_register, Lottery lottery, Person person)
        {
            Concurse = concurse;
            Hits = hits;
            Ticket_Amount = ticket_amount;
            Game_Checked = game_checked;
            Game_Register = game_register;
            Lottery = lottery;
            Person = person;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPerson_LotteryCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
