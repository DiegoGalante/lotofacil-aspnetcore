using System.Threading;
using System.Threading.Tasks;
using LoteriaFacil.Domain.Events;
using MediatR;


namespace LoteriaFacil.Domain.EventHandlers
{
    public class PersonLotteryEventHandler :
        INotificationHandler<PersonLotteryRegisteredEvent>,
        INotificationHandler<PersonLotteryUpdatedEvent>,
        INotificationHandler<PersonLotteryRemovedEvent>
    {
        public Task Handle(PersonLotteryRegisteredEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PersonLotteryUpdatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PersonLotteryRemovedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
