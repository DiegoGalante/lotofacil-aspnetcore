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
    public class PersonLotteryCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewPersonLotteryCommand, bool>,
        IRequestHandler<UpdatePersonLotteryCommand, bool>,
        IRequestHandler<RemovePersonLotteryCommand, bool>
    {

        private readonly IPersonLotteryRepository _PersonLotteryRepository;
        private readonly IMediatorHandler Bus;

        public PersonLotteryCommandHandler(IPersonLotteryRepository PersonLotteryRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _PersonLotteryRepository = PersonLotteryRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewPersonLotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var PersonLottery = new PersonLottery();
            if (message.Lottery != null)
            {
                PersonLottery = new PersonLottery(Guid.NewGuid(),
                                                      message.Concurse,
                                                      message.Game,
                                                      message.Lottery.Id,
                                                      message.Person.Id);
            }
            else
            {
                PersonLottery  = new PersonLottery(Guid.NewGuid(),
                                      message.Concurse,
                                      message.Game,
                                      message.Person.Id);
            }

            if (_PersonLotteryRepository.GetById(PersonLottery.Id) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Person Lottery Id has already been taken."));
                return Task.FromResult(false);
            }

            _PersonLotteryRepository.Add(PersonLottery);

            if (Commit())
            {
                Bus.RaiseEvent(new PersonLotteryRegisteredEvent(PersonLottery.Id, PersonLottery.Concurse, PersonLottery.Game, PersonLottery.Hits, PersonLottery.Ticket_Amount, PersonLottery.Game_Checked, PersonLottery.Game_Register, PersonLottery.Lottery, PersonLottery.Person));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePersonLotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var PersonLottery = new PersonLottery(message.Id,
                                                    message.Concurse,
                                                    message.Game,
                                                    message.Hits,
                                                    message.Ticket_Amount,
                                                    message.Game_Checked,
                                                    message.Game_Register,
                                                    message.Lottery.Id,
                                                    message.Person.Id);

            var existingPersonLottery = _PersonLotteryRepository.GetById(PersonLottery.Id);

            if (existingPersonLottery != null && existingPersonLottery.Id != PersonLottery.Id)
            {
                if (!existingPersonLottery.Equals(PersonLottery))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Person Lottery ID has already been taken."));
                    return Task.FromResult(false);
                }
            }

            _PersonLotteryRepository.Update(PersonLottery);

            if (Commit())
            {
                Bus.RaiseEvent(new PersonLotteryUpdatedEvent(PersonLottery.Id, PersonLottery.Concurse, PersonLottery.Game, PersonLottery.Hits, PersonLottery.Ticket_Amount, PersonLottery.Game_Checked, PersonLottery.Game_Register, PersonLottery.Lottery, PersonLottery.Person));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemovePersonLotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _PersonLotteryRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new PersonRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _PersonLotteryRepository.Dispose();
        }
    }
}
