using System.Threading;
using System.Threading.Tasks;
using LoteriaFacil.Domain.Events;
using MediatR;


namespace LoteriaFacil.Domain.EventHandlers
{
    public class PersonEventHandler :
        INotificationHandler<PersonRegisteredEvent>,
        INotificationHandler<PersonUpdatedEvent>,
        INotificationHandler<PersonRemovedEvent>
    {
        public Task Handle(PersonRegisteredEvent notification, CancellationToken cancellationToken)
        {
            //Envia alguma notificação de e-mail, por exemplo
            return Task.CompletedTask;
        }

        public Task Handle(PersonUpdatedEvent notification, CancellationToken cancellationToken)
        {
            //Envia alguma notificação de e-mail, por exemplo
            return Task.CompletedTask;
        }

        public Task Handle(PersonRemovedEvent notification, CancellationToken cancellationToken)
        {
            //Envia alguma notificação de e-mail, por exemplo
            return Task.CompletedTask;
        }
    }
}
