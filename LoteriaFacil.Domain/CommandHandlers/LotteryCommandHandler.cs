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
    public class LotteryCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewLotteryCommand, bool>,
        IRequestHandler<UpdateLotteryCommand, bool>,
        IRequestHandler<RemoveLotteryCommand, bool>

    {
        private readonly ILotteryRepository _lotteryRepository;
        private readonly IMediatorHandler Bus;

        public LotteryCommandHandler(ILotteryRepository lotteryRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _lotteryRepository = lotteryRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewLotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var lottery = new Lottery(Guid.NewGuid(),
                                      message.Concurse, message.DtConcurse, message.Game,
                                      message.Hit15, message.Hit14, message.Hit13, message.Hit12, message.Hit11,
                                      message.Shared15, message.Shared14, message.Shared13, message.Shared12, message.Shared11,
                                      message.DtNextConcurse, message.TypeLottery);


            if (_lotteryRepository.GetById(lottery.Id) != null && _lotteryRepository.GetByTypeLotteryId(lottery.TypeLottery.Id) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Lottery ID has already been taken."));
                return Task.FromResult(false);
            }

            _lotteryRepository.Add(lottery);

            if (Commit())
            {
                Bus.RaiseEvent(new LotteryRegisteredEvent(lottery.Id, lottery.Concurse, lottery.DtConcurse, lottery.Game,
                                                           lottery.Hit15, lottery.Hit14, lottery.Hit13, lottery.Hit12, lottery.Hit11,
                                                           lottery.Shared15, lottery.Shared14, lottery.Shared13, lottery.Shared12, lottery.Shared11,
                                                           lottery.DtNextConcurse, lottery.TypeLottery));

            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateLotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var lottery = new Lottery(message.Id,
                                      message.Concurse, message.DtConcurse, message.Game,
                                      message.Hit15, message.Hit14, message.Hit13, message.Hit12, message.Hit11,
                                      message.Shared15, message.Shared14, message.Shared13, message.Shared12, message.Shared11,
                                      message.DtNextConcurse, message.TypeLottery);

            var existingLottery = _lotteryRepository.GetById(lottery.Id);

            if (existingLottery != null && existingLottery.Id != lottery.Id)
            {
                if (!existingLottery.Equals(lottery))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Lottery ID has already been taken."));
                    return Task.FromResult(false);
                }
            }

            _lotteryRepository.Update(lottery);

            if (Commit())
            {
                Bus.RaiseEvent(new LotteryUpdatedEvent(lottery.Id, lottery.Concurse, lottery.DtConcurse, lottery.Game,
                                                          lottery.Hit15, lottery.Hit14, lottery.Hit13, lottery.Hit12, lottery.Hit11,
                                                          lottery.Shared15, lottery.Shared14, lottery.Shared13, lottery.Shared12, lottery.Shared11,
                                                          lottery.DtNextConcurse, lottery.TypeLottery));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveLotteryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _lotteryRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new LotteryRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _lotteryRepository.Dispose();
        }
    }
}
