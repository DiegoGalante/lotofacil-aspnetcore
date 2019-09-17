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
    public class Type_LotteryCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewType_LotteryCommand, bool>,
        IRequestHandler<UpdateType_LotteryCommand, bool>,
        IRequestHandler<RemoveType_LotteryCommand, bool>
    {
        private readonly IType_LotteryRepository _type_LotteryRepository;
        private readonly IMediatorHandler Bus;

        public Type_LotteryCommandHandler(IType_LotteryRepository type_LotteryRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _type_LotteryRepository = type_LotteryRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewType_LotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var type_lottery = new Type_Lottery(Guid.NewGuid(), message.Name, message.Tens_Min, message.Bet_Min, message.Hit_Min, message.Hit_Max);

            if (_type_LotteryRepository.GetById(type_lottery.Id) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "O ID deste tipo de jogo já está sendo usado!"));
                return Task.FromResult(false);
            }

            _type_LotteryRepository.Add(type_lottery);

            if (Commit())
            {
                Bus.RaiseEvent(new Type_LotteryRegisteredEvent(type_lottery.Id, type_lottery.Name, type_lottery.Tens_Min, type_lottery.Bet_Min, type_lottery.Hit_Min, type_lottery.Hit_Max));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateType_LotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var type_lottery = new Type_Lottery(message.Id, message.Name, message.Tens_Min, message.Bet_Min, message.Hit_Min, message.Hit_Max);
            var existingtype_lottery = _type_LotteryRepository.GetById(type_lottery.Id);

            if (existingtype_lottery != null && existingtype_lottery.Id != type_lottery.Id)
            {
                //se o obj retornado nao for igual ao 'person' 
                if (!existingtype_lottery.Equals(type_lottery))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "O e-mail desta pessoa já está sendo usado!"));
                    return Task.FromResult(false);
                }
            }

            _type_LotteryRepository.Update(type_lottery);

            if (Commit())
            {
                Bus.RaiseEvent(new Type_LotteryUpdatedEvent(type_lottery.Id, type_lottery.Name, type_lottery.Tens_Min, type_lottery.Bet_Min, type_lottery.Hit_Min, type_lottery.Hit_Max));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveType_LotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _type_LotteryRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new Type_LotteryRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _type_LotteryRepository.Dispose();
        }
    }
}
