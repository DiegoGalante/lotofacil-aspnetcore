using System.Threading;
using System.Threading.Tasks;
using LoteriaFacil.Domain.Events;
using MediatR;

namespace LoteriaFacil.Domain.EventHandlers
{
    public class LotteryEventHandler :
        INotificationHandler<LotteryRegisteredEvent>,
        INotificationHandler<LotteryUpdatedEvent>,
        INotificationHandler<LotteryRemovedEvent>
    {
        public Task Handle(LotteryRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(LotteryUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(LotteryRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }
    }
}
