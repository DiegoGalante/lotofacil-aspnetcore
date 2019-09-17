using AutoMapper;
using AutoMapper.QueryableExtensions;
using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Application.ViewModels;
using LoteriaFacil.Domain.Commands;
using LoteriaFacil.Domain.Core.Bus;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;

namespace LoteriaFacil.Application.Services
{
    public class ConfigurationAppService : IConfigurationAppService
    {
        private readonly IMapper _mapper;
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public ConfigurationAppService(IMapper mapper,
            IConfigurationRepository configurationRepository,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository)
        {
            this._mapper = mapper;
            this._configurationRepository = configurationRepository;
            this.Bus = bus;
            this._eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<ConfigurationViewModel> GetAll()
        {
            return _configurationRepository.GetAll().ProjectTo<ConfigurationViewModel>(_mapper.ConfigurationProvider);
        }

        public ConfigurationViewModel GetById(Guid id)
        {
            return _mapper.Map<ConfigurationViewModel>(_configurationRepository.GetById(id));
        }

        public void Register(ConfigurationViewModel configurationViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewConfigurationCommand>(configurationViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(ConfigurationViewModel configurationViewModel)
        {
            var updateCommand = _mapper.Map<UpdateConfigurationCommand>(configurationViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
