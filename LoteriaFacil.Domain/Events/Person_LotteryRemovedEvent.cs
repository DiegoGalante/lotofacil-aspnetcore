using LoteriaFacil.Domain.Core.Events;
using System;

namespace LoteriaFacil.Domain.Events
{
    public class Person_LotteryRemovedEvent : Event
    {
        public Person_LotteryRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
