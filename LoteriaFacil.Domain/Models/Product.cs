using LoteriaFacil.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Domain.Models
{
    public class Product : Entity
    {
        public Product(Guid Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public Product()
        {

        }

        public string Name { get; set; }
    }
}
