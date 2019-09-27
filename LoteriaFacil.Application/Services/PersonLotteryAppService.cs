using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
//using LoteriaFacil.Application.EventSourcedNormalizers;
using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Application.ViewModels;
using LoteriaFacil.Domain.Commands;
using LoteriaFacil.Domain.Core.Bus;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Domain.Models;
using LoteriaFacil.Infra.Data.Repository.EventSourcing;
namespace LoteriaFacil.Application.Services
{
    public class PersonLotteryAppService : IPersonLotteryAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonLotteryRepository _PersonLotteryRepository;
        private readonly ILotteryRepository _LotteryRepository;
        private readonly IUtilitiesAppService _utilitiesAppService;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        private readonly IJsonDashboardRepository _jsonDashboardRepository;
        private readonly IPersonGameRepository _personGameRepository;

        public PersonLotteryAppService(IMapper mapper,
                                        IPersonLotteryRepository PersonLotteryRepository,
                                        ILotteryRepository lotteryRepository,
                                        IUtilitiesAppService utilitiesAppService,
                                        IEventStoreRepository eventStoreRepository,
                                        IMediatorHandler bus,

                                        IJsonDashboardRepository jsonDashboardRepository,
                                        IPersonGameRepository personGameRepository)
        {
            _mapper = mapper;
            _PersonLotteryRepository = PersonLotteryRepository;
            _LotteryRepository = lotteryRepository;
            _utilitiesAppService = utilitiesAppService;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;

            _jsonDashboardRepository = jsonDashboardRepository;
            _personGameRepository = personGameRepository;
        }

        public void Register(PersonLotteryViewModel PersonLotteryViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewPersonLotteryCommand>(PersonLotteryViewModel);
            Bus.SendCommand(registerCommand);
        }

        IEnumerable<PersonLotteryViewModel> IPersonLotteryAppService.GetAll()
        {
            return _PersonLotteryRepository.GetAll().ProjectTo<PersonLotteryViewModel>(_mapper.ConfigurationProvider);
        }

        public void Update(PersonLotteryViewModel PersonLotteryViewModel)
        {
            var updateCommand = _mapper.Map<UpdatePersonLotteryCommand>(PersonLotteryViewModel);
            Bus.SendCommand(updateCommand);
        }

        public PersonLotteryViewModel GetById(Guid id)
        {
            return _mapper.Map<PersonLotteryViewModel>(_PersonLotteryRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemovePersonLotteryCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public Object GetJsonDashboard(int concurse = 0)
        {
            JsonDashboard lottery = new JsonDashboard();
            if (concurse > 0)
                lottery = _jsonDashboardRepository.GetFunctionJsonDashBoard(concurse);

            if (lottery == null || lottery.Id.Equals(Guid.Empty))
                lottery = _jsonDashboardRepository.GetFunctionJsonDashBoard(_LotteryRepository.GetLast().Concurse);

            return new { concurse = lottery, personGame = "", amount_tickets = 0 };
        }

        internal List<PersonGame> PersonGame(out decimal amount, int concurse = 0, Guid? personId = null)
        {
            List<PersonGame> _personGame = new List<PersonGame>();

            if (concurse == 0)
                concurse = _LotteryRepository.GetLast().Concurse;

            if (personId != null)
                _personGame = _personGameRepository.GetFunctionJogoPessoa((Guid)personId, concurse).ToList();
            else
                _personGame = _personGameRepository.GetFunctionJogoPessoa(concurse).ToList();

            amount = _personGame.Sum(x => x.Ticket_Amount);

            return _personGame;
        }

        public Object GetPersonGame(Guid personId, int concurse = 0)
        {
            decimal amount = 0;
            List<PersonGame> _personGame = PersonGame(out amount, concurse, personId);

            return new { personGame = _personGame, amount_tickets = amount };
        }

        public Object GetPersonGame(int concurse = 0)
        {
            decimal amount = 0;
            List<PersonGame> _personGame = PersonGame(out amount, concurse);

            return new { personGame = _personGame, amount_tickets = amount };
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
