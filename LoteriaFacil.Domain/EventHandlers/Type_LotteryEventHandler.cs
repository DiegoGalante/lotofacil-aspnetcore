using System.Threading;
using System.Threading.Tasks;
using LoteriaFacil.Domain.Events;
using MediatR;

namespace LoteriaFacil.Domain.EventHandlers
{
    public class Type_LotteryEventHandler :
        INotificationHandler<Type_LotteryRegisteredEvent>,
        INotificationHandler<Type_LotteryUpdatedEvent>,
        INotificationHandler<Type_LotteryRemovedEvent>
    {
        public Task Handle(Type_LotteryRegisteredEvent notification, CancellationToken cancellationToken)
        {
            //Envia algum e-mail ou algo assim
            return Task.CompletedTask;
        }

        public Task Handle(Type_LotteryUpdatedEvent notification, CancellationToken cancellationToken)
        {
            //Envia algum e-mail ou algo assim
            return Task.CompletedTask;
        }

        public Task Handle(Type_LotteryRemovedEvent notification, CancellationToken cancellationToken)
        {
            //Envia algum e-mail ou algo assim
            return Task.CompletedTask;
        }
    }
}
