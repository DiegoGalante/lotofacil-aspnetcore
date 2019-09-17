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
    public class PersonAppService : IPersonAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public PersonAppService(IMapper mapper,
                                IPersonRepository personRepository,
                                IMediatorHandler bus,
                                IEventStoreRepository eventStoreRepository)
        {
            this._mapper = mapper;
            this._personRepository = personRepository;
            this.Bus = bus;
            this._eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<PersonViewModel> GetAll()
        {
            return _personRepository.GetAll().ProjectTo<PersonViewModel>(_mapper.ConfigurationProvider);
        }

        public PersonViewModel GetById(Guid id)
        {
            return _mapper.Map<PersonViewModel>(_personRepository.GetById(id));
        }

        public void Register(PersonViewModel personViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewPersonCommand>(personViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(PersonViewModel personViewModel)
        {
            var updateCommand = _mapper.Map<UpdatePersonCommand>(personViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
