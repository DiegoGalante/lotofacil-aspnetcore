using LoteriaFacil.Domain.Core.Events;
using System;

namespace LoteriaFacil.Domain.Events
{
    public class PersonRemovedEvent : Event
    {
        public PersonRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
