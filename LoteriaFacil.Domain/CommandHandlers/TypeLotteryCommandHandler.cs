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
    public class TypeLotteryCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewTypeLotteryCommand, bool>,
        IRequestHandler<UpdateTypeLotteryCommand, bool>,
        IRequestHandler<RemoveTypeLotteryCommand, bool>
    {
        private readonly ITypeLotteryRepository _TypeLotteryRepository;
        private readonly IMediatorHandler Bus;

        public TypeLotteryCommandHandler(ITypeLotteryRepository TypeLotteryRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _TypeLotteryRepository = TypeLotteryRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewTypeLotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var TypeLottery = new TypeLottery(Guid.NewGuid(), message.Name, message.Tens_Min, message.Bet_Min, message.Hit_Min, message.Hit_Max);

            if (_TypeLotteryRepository.GetById(TypeLottery.Id) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "O ID deste tipo de jogo já está sendo usado!"));
                return Task.FromResult(false);
            }

            _TypeLotteryRepository.Add(TypeLottery);

            if (Commit())
            {
                Bus.RaiseEvent(new TypeLotteryRegisteredEvent(TypeLottery.Id, TypeLottery.Name, TypeLottery.Tens_Min, TypeLottery.Bet_Min, TypeLottery.Hit_Min, TypeLottery.Hit_Max));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateTypeLotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var TypeLottery = new TypeLottery(message.Id, message.Name, message.Tens_Min, message.Bet_Min, message.Hit_Min, message.Hit_Max);
            var existingTypeLottery = _TypeLotteryRepository.GetById(TypeLottery.Id);

            if (existingTypeLottery != null && existingTypeLottery.Id != TypeLottery.Id)
            {
                //se o obj retornado nao for igual ao 'person' 
                if (!existingTypeLottery.Equals(TypeLottery))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "O e-mail desta pessoa já está sendo usado!"));
                    return Task.FromResult(false);
                }
            }

            _TypeLotteryRepository.Update(TypeLottery);

            if (Commit())
            {
                Bus.RaiseEvent(new TypeLotteryUpdatedEvent(TypeLottery.Id, TypeLottery.Name, TypeLottery.Tens_Min, TypeLottery.Bet_Min, TypeLottery.Hit_Min, TypeLottery.Hit_Max));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveTypeLotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _TypeLotteryRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new TypeLotteryRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _TypeLotteryRepository.Dispose();
        }
    }
}
