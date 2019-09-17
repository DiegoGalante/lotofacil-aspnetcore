using LoteriaFacil.Domain.Core.Events;
using System;

namespace LoteriaFacil.Domain.Events
{
    public class Type_LotteryRemovedEvent : Event
    {
        public Type_LotteryRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
