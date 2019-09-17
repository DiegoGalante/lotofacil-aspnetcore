using System;
using LoteriaFacil.Domain.Core.Events;
using LoteriaFacil.Domain.Models;

namespace LoteriaFacil.Domain.Events
{
    public class Person_LotteryRegisteredEvent : Event
    {
        public Person_LotteryRegisteredEvent(Guid id, int concurse, string game, int hits, decimal ticket_amount, DateTime? game_checked, DateTime game_register, Lottery lottery, Person person)
        {
            Id = id;
            Concurse = concurse;
            Hits = hits;
            Ticket_Amount = ticket_amount;
            Game_Checked = game_checked;
            Game_Register = game_register;
            Lottery = lottery;
            Person = person;
        }

        public Guid Id { get; set; }
        public Lottery Lottery { get; private set; }
        public Person Person { get; private set; }

        public int Concurse { get; private set; }

        /// <summary>
        /// Dezenas do jogo.
        /// </summary>
        public string Game { get; private set; }

        /// <summary>
        /// Quantidade de acertos.
        /// </summary>
        public int Hits { get; private set; }

        /// <summary>
        /// Valor R$ a receber do bilhete.
        /// </summary>
        public decimal Ticket_Amount { get; private set; }

        /// <summary>
        /// Jogo checado.
        /// </summary>
        public DateTime? Game_Checked { get; private set; }

        /// <summary>
        /// Data do registro do jogo.
        /// </summary>
        public DateTime Game_Register { get; private set; }
    }
}
