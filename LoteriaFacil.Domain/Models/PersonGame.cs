using LoteriaFacil.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Domain.Models
{
    public class PersonGame : Entity
    {
        public PersonGame()
        {

        }

        public Guid LotteryId { get; set; }
        public Guid PesId { get; set; }

        public int Concurse { get; set; }
        public string Name { get; set; }
        public string Game { get; set; }
        public int Hits { get; set; }
        public decimal Ticket_Amount { get; set; }
    }
}
