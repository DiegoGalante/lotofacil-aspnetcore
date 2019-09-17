using System;
using System.Threading;
using System.Threading.Tasks;
using LoteriaFacil.Domain.Commands;
using LoteriaFacil.Domain.Core.Bus;
using LoteriaFacil.Domain.Core.Notifications;
using LoteriaFacil.Domain.Events;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Domain.Models;
using MediatR;

namespace LoteriaFacil.Domain.CommandHandlers
{
    public class ConfigurationCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewConfigurationCommand, bool>,
        IRequestHandler<UpdateConfigurationCommand, bool>
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IMediatorHandler Bus;

        public ConfigurationCommandHandler(IConfigurationRepository configurationRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _configurationRepository = configurationRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewConfigurationCommand message, CancellationToken cancellationToken)
        {
            //se nao for válido
            //if (!message.IsValid())
            //{
            //    NotifyValidationErrors(message);
            //    return Task.FromResult(false);
            //}

            var configuration = new Configuration(Guid.NewGuid(), message.Calcular_Dezenas_Sem_Pontuacao, message.Enviar_Email_Manualmente, message.Enviar_Email_Automaticamente, message.Checar_Jogo_Online, message.Valor_Minimo_Para_Envio_Email);

            if (_configurationRepository.GetConfigurationById(configuration.Id) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "O id desta configuração já existe!"));
                return Task.FromResult(false);
            }

            _configurationRepository.Add(configuration);

            if (Commit())
            {
                Bus.RaiseEvent(new ConfigurationRegisteredEvent(configuration.Id, configuration.Calcular_Dezenas_Sem_Pontuacao,
                configuration.Enviar_Email_Manualmente,
                configuration.Enviar_Email_Automaticamente,
                configuration.Checar_Jogo_Online,
                configuration.Valor_Minimo_Para_Envio_Email));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateConfigurationCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var configuration = new Configuration(message.Id, message.Calcular_Dezenas_Sem_Pontuacao, message.Enviar_Email_Manualmente, message.Enviar_Email_Automaticamente, message.Checar_Jogo_Online, message.Valor_Minimo_Para_Envio_Email);
            var existingConfiguration = _configurationRepository.GetConfigurationById(configuration.Id);

            if (existingConfiguration != null && existingConfiguration.Id != configuration.Id)
            {
                if (!existingConfiguration.Equals(configuration))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "O ID desta configuração já está sendo usado!"));
                    return Task.FromResult(false);
                }
            }

            _configurationRepository.Update(configuration);

            if (Commit())
            {
                try
                {
                    Bus.RaiseEvent(new ConfigurationUpdatedEvent(configuration.Id, configuration.Calcular_Dezenas_Sem_Pontuacao,
                                             configuration.Enviar_Email_Manualmente,
                                             configuration.Enviar_Email_Automaticamente,
                                             configuration.Checar_Jogo_Online,
                                             configuration.Valor_Minimo_Para_Envio_Email));
                }
                catch (Exception ex)
                {

                    //throw;
                }
            }

            return Task.FromResult(true);
        }
    }
}
