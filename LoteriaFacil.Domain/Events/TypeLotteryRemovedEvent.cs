using LoteriaFacil.Domain.Core.Events;
using System;

namespace LoteriaFacil.Domain.Events
{
    public class TypeLotteryRemovedEvent : Event
    {
        public TypeLotteryRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
