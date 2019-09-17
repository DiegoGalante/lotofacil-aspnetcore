using System;
using LoteriaFacil.Domain.Core.Commands;
using LoteriaFacil.Domain.Models;

namespace LoteriaFacil.Domain.Commands
{
    public abstract class Person_LotteryCommand : Command
    {
        public Guid Id { get; protected set; }

        public Lottery Lottery { get; protected set; }
        public Person Person { get; protected set; }

        public int Concurse { get; protected set; }

        /// <summary>
        /// Dezenas do jogo.
        /// </summary>
        public string Game { get; protected set; }

        /// <summary>
        /// Quantidade de acertos.
        /// </summary>
        public int Hits { get; protected set; }

        /// <summary>
        /// Valor R$ a receber do bilhete.
        /// </summary>
        public decimal Ticket_Amount { get; protected set; }

        /// <summary>
        /// Jogo checado.
        /// </summary>
        public DateTime? Game_Checked { get; protected set; }

        /// <summary>
        /// Data do registro do jogo.
        /// </summary>
        public DateTime Game_Register { get; protected set; }
    }
}
