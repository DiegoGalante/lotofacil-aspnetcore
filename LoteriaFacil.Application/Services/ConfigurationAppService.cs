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
using System.Threading.Tasks;

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

        public async Task<IEnumerable<ConfigurationViewModel>> GetAll()
        {
            return await Task.Run(() => _configurationRepository.GetAll().ProjectTo<ConfigurationViewModel>(_mapper.ConfigurationProvider));
        }

        public async Task<ConfigurationViewModel> GetById(Guid id)
        {
            return await Task.Run(() => _mapper.Map<ConfigurationViewModel>(_configurationRepository.GetById(id)));
        }

        public async Task Register(ConfigurationViewModel configurationViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewConfigurationCommand>(configurationViewModel);
            await Bus.SendCommand(registerCommand);
        }

        public async Task Update(ConfigurationViewModel configurationViewModel)
        {
            var updateCommand = _mapper.Map<UpdateConfigurationCommand>(configurationViewModel);
            await Bus.SendCommand(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
