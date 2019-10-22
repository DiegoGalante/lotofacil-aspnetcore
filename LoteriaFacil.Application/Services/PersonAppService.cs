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

        internal async Task Gerar_ScriptInsertPerson()
        {
            //List<Guid> listGuid = new List<Guid>();

            //PersonViewModel person = new PersonViewModel();
            //List<int> integerList = Enumerable.Range(1, 200000).ToList();
            ////var option = new ParallelOptions() { MaxDegreeOfParallelism = 10 };

            //foreach (int i in integerList)
            //{
            //    var cont = i;
            //    Guid guidId = Guid.NewGuid();

            //    //while (listGuid.Contains(guidId))
            //    //    guidId = Guid.NewGuid();

            //    person = new PersonViewModel
            //    {
            //        Name = $"Pessoa Teste {cont}",
            //        Active = false,
            //        Email = $"teste_{cont}@teste.com",
            //        Password = "",
            //        DtRegister = DateTime.Now,
            //        Id = guidId
            //    };

            //    //listGuid.Add(guidId);

            //    var caminho_padrao = System.IO.Directory.GetCurrentDirectory();
            //    var caminho = string.Empty;

            //    if (cont <= 50000)
            //        caminho = caminho_padrao + @"\ArquivoInsertPerson_1a50k.txt";
            //    else if (cont >= 50000 && cont <= 100000)
            //        caminho = caminho_padrao + @"\ArquivoInsertPerson_50ka100k.txt";
            //    else if (cont >= 100000 && cont <= 150000)
            //        caminho = caminho_padrao + @"\ArquivoInsertPerson_100a150k.txt";
            //    else if (cont >= 150000 && cont <= 200000)
            //        caminho = caminho_padrao + @"\ArquivoInsertPerson_150a200k.txt";

            //    var texto = $"INSERT INTO PERSON(Id, Name, Email, Password, Active) VALUES(NEWID(), '{person.Name}', '{person.Email}', '{person.Password}', {(person.Active ? 1 : 0)});";
            //    using (System.IO.StreamWriter fileWriterAlterado = new System.IO.StreamWriter(caminho, true, System.Text.Encoding.UTF8))
            //    {
            //        await fileWriterAlterado.WriteLineAsync(texto);
            //        fileWriterAlterado.Close();
            //        fileWriterAlterado.Dispose();
            //    }

            //    person = new PersonViewModel();


            //}

            for (int i = 1; i <= 4; i++)
            {
                var cont = i;
                var caminho_padrao = System.IO.Directory.GetCurrentDirectory();
                var caminho = string.Empty;
                var nome_arquivo = string.Empty;

                var start = 1;
                var end = 10;

                switch (cont)
                {
                    case 1:
                        nome_arquivo = @"\ArquivoInsertPerson_1a50k.txt";
                        caminho = caminho_padrao + nome_arquivo;
                        end = 50000;
                        break;

                    case 2:
                        nome_arquivo = @"\ArquivoInsertPerson_50ka100k.txt";
                        caminho = caminho_padrao + nome_arquivo;
                        start = 50001;
                        end = 100000;
                        break;

                    case 3:
                        nome_arquivo = @"\ArquivoInsertPerson_100a150k.txt";
                        caminho = caminho_padrao + nome_arquivo;
                        start = 100001;
                        end = 150000;
                        break;

                    case 4:
                        nome_arquivo = @"\ArquivoInsertPerson_150a200k.txt";
                        caminho = caminho_padrao + nome_arquivo;
                        start = 150001;
                        end = 200000;
                        break;

                    default:
                        break;
                }

                var watch1 = System.Diagnostics.Stopwatch.StartNew();
                List<string> textos = await Task.Run(() => RetornaTexto(start, end));
                watch1.Stop();

                var watch = System.Diagnostics.Stopwatch.StartNew();
                Parallel.ForEach(textos, (texto) =>
                {
                    Task.WhenAll(GravaArquivo(caminho, texto));
                });
                watch.Stop();

                var arquivo_log = caminho_padrao + @"\ArquivoInsertPersonLog.txt";
                using (System.IO.StreamWriter fileWriterAlterado = new System.IO.StreamWriter(arquivo_log, true, System.Text.Encoding.UTF8))
                {
                    var texto = $"Arquivo {nome_arquivo}. Tempo de execução do RetornaTexto {watch1.Elapsed.TotalSeconds} segundos,{watch1.ElapsedMilliseconds} milisegundos; Quantidade de linhas que devem ser criadas {end}, quantidade de linhas que foram geradas {textos.Count}. Tempo de execução do GravaArquivo (no parallel): {watch.Elapsed.TotalHours} hora(s), {watch.Elapsed.TotalMinutes} minutos, {watch.Elapsed.TotalSeconds} segundos, {watch.ElapsedMilliseconds} milisegundos.{Environment.NewLine}";
                    await fileWriterAlterado.WriteLineAsync(texto);
                    fileWriterAlterado.Close();
                    fileWriterAlterado.Dispose();
                }

            }

        }

        private async Task GravaArquivo(string caminho, string texto)
        {
            using (System.IO.StreamWriter fileWriterAlterado = new System.IO.StreamWriter(caminho, true, System.Text.Encoding.UTF8))
            {
                await fileWriterAlterado.WriteLineAsync(texto);
                fileWriterAlterado.Close();
                fileWriterAlterado.Dispose();
            }
        }

        private List<string> RetornaTexto(int start = 1, int end = 200000)
        {
            PersonViewModel person = new PersonViewModel();
            List<int> integerList = Enumerable.Range(start, end).ToList();

            List<string> retorno = new List<string>();

            Parallel.ForEach<int>(integerList, (i) =>
            {
                var cont = i;
                Guid guidId = Guid.NewGuid();

                person = new PersonViewModel
                {
                    Name = $"Pessoa Teste {cont}",
                    Active = false,
                    Email = $"teste_{cont}@teste.com",
                    Password = "",
                    DtRegister = DateTime.Now,
                    Id = guidId
                };

                var texto = $"INSERT INTO PERSON(Id, Name, Email, Password, Active) VALUES(NEWID(), '{person.Name}', '{person.Email}', '{person.Password}', {(person.Active ? 1 : 0)});";
                retorno.Add(texto);
                person = new PersonViewModel();
            });

            return retorno;
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

    }
}
