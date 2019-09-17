using System.Threading;
using System.Threading.Tasks;
using LoteriaFacil.Domain.Events;
using MediatR;


namespace LoteriaFacil.Domain.EventHandlers
{
    public class ConfigurationEventHandler :
        INotificationHandler<ConfigurationRegisteredEvent>,
        INotificationHandler<ConfigurationUpdatedEvent>
    {
        public Task Handle(ConfigurationRegisteredEvent notification, CancellationToken cancellationToken)
        {
            //Envia algum e-mail ou algo assim
            return Task.CompletedTask;
        }

        public Task Handle(ConfigurationUpdatedEvent notification, CancellationToken cancellationToken)
        {
            //Envia algum e-mail ou algo assim
            return Task.CompletedTask;
        }
    }
}
