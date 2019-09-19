using System.Threading;
using System.Threading.Tasks;
using LoteriaFacil.Domain.Events;
using MediatR;

namespace LoteriaFacil.Domain.EventHandlers
{
    public class TypeLotteryEventHandler :
        INotificationHandler<TypeLotteryRegisteredEvent>,
        INotificationHandler<TypeLotteryUpdatedEvent>,
        INotificationHandler<TypeLotteryRemovedEvent>
    {
        public Task Handle(TypeLotteryRegisteredEvent notification, CancellationToken cancellationToken)
        {
            //Envia algum e-mail ou algo assim
            return Task.CompletedTask;
        }

        public Task Handle(TypeLotteryUpdatedEvent notification, CancellationToken cancellationToken)
        {
            //Envia algum e-mail ou algo assim
            return Task.CompletedTask;
        }

        public Task Handle(TypeLotteryRemovedEvent notification, CancellationToken cancellationToken)
        {
            //Envia algum e-mail ou algo assim
            return Task.CompletedTask;
        }
    }
}
