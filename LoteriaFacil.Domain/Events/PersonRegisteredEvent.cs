using System;
using LoteriaFacil.Domain.Core.Events;

namespace LoteriaFacil.Domain.Events
{
    public class PersonRegisteredEvent : Event
    {
        public PersonRegisteredEvent(Guid id, string name, string email, string password, DateTime dtRegiser, bool active)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            DtRegister = dtRegiser;
            Active = active;
            //Pq esse aggregate Id?
            AggregateId = id;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }
        public string Email { get; private set; }

        public string Password { get; private set; }

        public DateTime DtRegister { get; private set; }

        public bool Active { get; private set; }
    }
}
