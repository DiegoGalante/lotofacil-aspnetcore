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
    public class Person_LotteryCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewPerson_LotteryCommand, bool>,
        IRequestHandler<UpdatePerson_LotteryCommand, bool>,
        IRequestHandler<RemovePerson_LotteryCommand, bool>
    {

        private readonly IPerson_LotteryRepository _person_LotteryRepository;
        private readonly IMediatorHandler Bus;

        public Person_LotteryCommandHandler(IPerson_LotteryRepository person_LotteryRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _person_LotteryRepository = person_LotteryRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewPerson_LotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var person_lottery = new Person_Lottery(Guid.NewGuid(),
                                                    message.Concurse,
                                                    message.Game,
                                                    message.Hits,
                                                    message.Ticket_Amount,
                                                    message.Game_Checked,
                                                    DateTime.Now,
                                                    message.Lottery,
                                                    message.Person);

            if (_person_LotteryRepository.GetById(person_lottery.Id) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Person Lottery Id has already been taken."));
                return Task.FromResult(false);
            }

            _person_LotteryRepository.Add(person_lottery);

            if (Commit())
            {
                Bus.RaiseEvent(new Person_LotteryRegisteredEvent(person_lottery.Id, person_lottery.Concurse, person_lottery.Game, person_lottery.Hits, person_lottery.Ticket_Amount, person_lottery.Game_Checked, person_lottery.Game_Register, person_lottery.Lottery, person_lottery.Person));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePerson_LotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var person_lottery = new Person_Lottery(message.Id,
                                                    message.Concurse,
                                                    message.Game,
                                                    message.Hits,
                                                    message.Ticket_Amount,
                                                    message.Game_Checked,
                                                    message.Game_Register,
                                                    message.Lottery,
                                                    message.Person);

            var existingPerson_lottery = _person_LotteryRepository.GetById(person_lottery.Id);

            if (existingPerson_lottery != null && existingPerson_lottery.Id != person_lottery.Id)
            {
                if (!existingPerson_lottery.Equals(person_lottery))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Person Lottery ID has already been taken."));
                    return Task.FromResult(false);
                }
            }

            _person_LotteryRepository.Update(person_lottery);

            if (Commit())
            {
                Bus.RaiseEvent(new Person_LotteryUpdatedEvent(person_lottery.Id, person_lottery.Concurse, person_lottery.Game, person_lottery.Hits, person_lottery.Ticket_Amount, person_lottery.Game_Checked, person_lottery.Game_Register, person_lottery.Lottery, person_lottery.Person));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemovePerson_LotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _person_LotteryRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new PersonRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _person_LotteryRepository.Dispose();
        }
    }
}
