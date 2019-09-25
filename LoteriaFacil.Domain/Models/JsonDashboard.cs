using LoteriaFacil.Domain.Core.Models;
using System;

namespace LoteriaFacil.Domain.Models
{
    public class JsonDashboard : Entity
    {
        public JsonDashboard(int concurse, string dtConcurse, string dtExtense, string game, 
                              int hit15, decimal shared15, decimal percent15,
                              int hit14, decimal shared14, decimal percent14,
                              int hit13, decimal shared13, decimal percent13,
                              int hit12, decimal shared12, decimal percent12,
                              int hit11, decimal shared11, decimal percent11)
        {
            this.Id = Guid.Empty;
            this.Concurse = concurse;
            this.DtConcurse = dtConcurse;
            this.DtExtense = dtExtense;
            this.Game = game;

            this.Hit15 = hit15;
            this.Shared15 = shared15;
            this.Percent15 = percent15;

            this.Hit14 = hit14;
            this.Shared14 = shared14;
            this.Percent14 = percent14;

            this.Hit13 = hit13;
            this.Shared13 = shared13;
            this.Percent13 = percent13;

            this.Hit12 = hit12;
            this.Shared12 = shared12;
            this.Percent12 = percent12;

            this.Hit11 = hit11;
            this.Shared11 = shared11;
            this.Percent11 = percent11;
        }

        public JsonDashboard()
        {

        }

        public int Concurse { get; set; }
        public string DtConcurse { get; set; }
        public string DtExtense { get; set; }
        public string Game { get; set; }

        public int Hit15 { get; set; }
        public decimal Shared15 { get; set; }
        public decimal Percent15 { get; set; }

        public int Hit14 { get; set; }
        public decimal Shared14 { get; set; }
        public decimal Percent14 { get; set; }

        public int Hit13 { get; set; }
        public decimal Shared13 { get; set; }
        public decimal Percent13 { get; set; }

        public int Hit12 { get; set; }
        public decimal Shared12 { get; set; }
        public decimal Percent12 { get; set; }

        public int Hit11 { get; set; }
        public decimal Shared11 { get; set; }
        public decimal Percent11 { get; set; }
    }
}
