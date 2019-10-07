using LoteriaFacil.Domain.Core.Models;
using System;

namespace LoteriaFacil.Domain.Models
{
    public class Person : Entity
    {
        public Person(Guid id, string name, string email, string password, DateTime dtRegister, bool active)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Password = password == null ? string.Empty : password;
            this.DtRegister = dtRegister;
            this.Active = active;
        }

        public Person() { }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public string Password { get; protected set; }

        public DateTime DtRegister { get; protected set; }

        public bool Active { get; protected set; }
    }
}
