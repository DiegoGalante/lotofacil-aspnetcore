using System;
using System.Collections.Generic;
using LoteriaFacil.Domain.Core.Events;

namespace LoteriaFacil.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}