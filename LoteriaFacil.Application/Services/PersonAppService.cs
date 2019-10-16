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
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<PersonViewModel>> GetAll()
        {
            return await Task.Run(() => _personRepository.GetAll().ProjectTo<PersonViewModel>(_mapper.ConfigurationProvider));
        }

        internal void Gerar_ScriptInsertPerson()
        {
            List<Guid> listGuid = new List<Guid>();

            PersonViewModel person = new PersonViewModel();

            List<int> integerList = Enumerable.Range(1, 200000).ToList();

            var option = new ParallelOptions() { MaxDegreeOfParallelism = 2 };

            Parallel.ForEach<int>(integerList, option, (i) =>
             {
                 var cont = i;
                 Guid guidId = Guid.NewGuid();

                 while (listGuid.Contains(guidId))
                     guidId = Guid.NewGuid();

                 person = new PersonViewModel
                 {
                     Name = $"Pessoa Teste {cont}",
                     Active = false,
                     Email = $"teste_{cont}@teste.com",
                     Password = "",
                     DtRegister = DateTime.Now,
                     Id = guidId
                 };

                 listGuid.Add(guidId);

                 var caminho_padrao = System.IO.Directory.GetCurrentDirectory();
                 var caminho = string.Empty;

                 if (cont <= 50000)
                     caminho = caminho_padrao + @"\ArquivoInsertPerson_1a50k.txt";
                 else if (cont >= 50000 && cont <= 100000)
                     caminho = caminho_padrao + @"\ArquivoInsertPerson_50ka100k.txt";
                 else if (cont >= 100000 && cont <= 150000)
                     caminho = caminho_padrao + @"\ArquivoInsertPerson_100a150k.txt";
                 else if (cont >= 150000 && cont <= 200000)
                     caminho = caminho_padrao + @"\ArquivoInsertPerson_150a200k.txt";

                 var texto = $"INSERT INTO PERSON(Id, Name, Email, Password, DtRegister, Active) VALUES('{person.Id}', '{person.Name}', '{person.Email}', '{person.Password}', '{person.DtRegister.ToString()}', {(person.Active ? 1 : 0)});";
                 using (System.IO.StreamWriter fileWriterAlterado = new System.IO.StreamWriter(caminho, true, System.Text.Encoding.UTF8))
                 {
                     fileWriterAlterado.WriteLine(texto);
                     fileWriterAlterado.Close();
                     fileWriterAlterado.Dispose();
                 }
                 person = new PersonViewModel();

             });
        }

        public async Task<PersonViewModel> GetById(Guid id)
        {
            return await Task.Run(() => _mapper.Map<PersonViewModel>(_personRepository.GetById(id)));
        }

        public async Task Register(PersonViewModel personViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewPersonCommand>(personViewModel);
            await Bus.SendCommand(registerCommand);
        }

        public async Task Update(PersonViewModel personViewModel)
        {
            var updateCommand = _mapper.Map<UpdatePersonCommand>(personViewModel);
            await Bus.SendCommand(updateCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Remove(Guid id)
        {
            var removeCommand = new RemovePersonCommand(id);
            await Bus.SendCommand(removeCommand);
        }

        public async Task<IEnumerable<PersonViewModel>> GetByDemand(int start = 0, int end = 0)
        {
            return null;
            //return _mapper.Map<PersonViewModel>(_personRepository.GetByDemand(start, end).ToAsyncEnumerable(PersonViewModel));
            //return await Task.Run(() => _mapper.Map<PersonViewModel>(_personRepository.GetByDemand(start, end))).ToAsyncEnumerable<PersonViewModel>;
        }
    }
}
