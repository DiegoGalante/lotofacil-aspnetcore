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
    public class PersonCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewPersonCommand, bool>,
        IRequestHandler<UpdatePersonCommand, bool>,
        IRequestHandler<RemovePersonCommand, bool>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMediatorHandler Bus;

        public PersonCommandHandler(IPersonRepository personRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _personRepository = personRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewPersonCommand message, CancellationToken cancellationToken)
        {
            //se nao for válido
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var person = new Person(Guid.NewGuid(), message.Name, message.Email, message.Password, DateTime.Now, message.Active);

            if (_personRepository.GetByEmail(person.Email) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "O e-mail desta pessoa já está sendo usado!"));
                return Task.FromResult(false);
            }

            _personRepository.Add(person);

            if (Commit())
            {
                Bus.RaiseEvent(new PersonRegisteredEvent(person.Id, person.Name, person.Email, person.Password, person.DtRegister, person.Active));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePersonCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var person = new Person(message.Id, message.Name, message.Email, message.Password, message.DtRegister, message.Active);
            var existingPerson = _personRepository.GetByEmail(person.Email);

            if (existingPerson != null && existingPerson.Id != person.Id)
            {
                //se o obj retornado nao for igual ao 'person' 
                if (!existingPerson.Equals(person))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "O e-mail desta pessoa já está sendo usado!"));
                    return Task.FromResult(false);
                }
            }

            _personRepository.Update(person);

            if (Commit())
            {
                Bus.RaiseEvent(new PersonUpdatedEvent(person.Id, person.Name, person.Email, person.Password, person.DtRegister, person.Active));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemovePersonCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _personRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new PersonRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _personRepository.Dispose();
        }
    }
}
