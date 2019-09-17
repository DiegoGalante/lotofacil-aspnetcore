using LoteriaFacil.Domain.Core.Events;
using System;

namespace LoteriaFacil.Domain.Events
{
   public class LotteryRemovedEvent : Event
    {
        public LotteryRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
