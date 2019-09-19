using System;
using System.Collections.Generic;
using LoteriaFacil.Domain.Core.Models;

namespace LoteriaFacil.Domain.Models
{
    public class PersonLottery : Entity
    {
        public PersonLottery(Guid id, int concurse, string game, int hits, decimal ticket_amount, DateTime? game_checked, DateTime game_register, Lottery lottery, Person person)
        {
            this.Id = id;
            this.Concurse = concurse;
            this.Game = game;
            this.Hits = hits;
            this.Ticket_Amount = ticket_amount;
            this.Game_Checked = game_checked;
            this.Game_Register = game_register;
            this.Lottery = lottery;
            this.Person = person;
        }

        public PersonLottery()
        {

        }

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

        ///// <summary>
        ///// Data de agendamento. Caso o jogo esteja agendado para ser verificado em um dia específico. NÃO UTILIZADO NO MOMENTO
        ///// </summary>
        //Scheduled_Game 
    }
}
