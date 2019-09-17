using System.Threading;
using System.Threading.Tasks;
using LoteriaFacil.Domain.Events;
using MediatR;


namespace LoteriaFacil.Domain.EventHandlers
{
    public class Person_LotteryEventHandler :
        INotificationHandler<Person_LotteryRegisteredEvent>,
        INotificationHandler<Person_LotteryUpdatedEvent>,
        INotificationHandler<Person_LotteryRemovedEvent>
    {
        public Task Handle(Person_LotteryRegisteredEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(Person_LotteryUpdatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(Person_LotteryRemovedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
