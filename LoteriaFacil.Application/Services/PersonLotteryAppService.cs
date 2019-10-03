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
using LoteriaFacil.Infra.CrossCutting.Identity.Services;
using LoteriaFacil.Infra.CrossCutting.Identity.Extensions;
using LoteriaFacil.Infra.Data.Repository.EventSourcing;
using LoteriaFacil.Infra.CrossCutting.Identity.Offline;

namespace LoteriaFacil.Application.Services
{
    public class PersonLotteryAppService : IPersonLotteryAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonLotteryRepository _PersonLotteryRepository;
        private readonly ILotteryRepository _LotteryRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        private readonly IJsonDashboardRepository _jsonDashboardRepository;
        private readonly IPersonGameRepository _personGameRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IConfigurationRepository _configurationRepository;

        private readonly IEmailSender _emailSender;

        public PersonLotteryAppService(IMapper mapper,
                                        IPersonLotteryRepository PersonLotteryRepository,
                                        ILotteryRepository lotteryRepository,
                                        IEventStoreRepository eventStoreRepository,
                                        IMediatorHandler bus,

                                        IJsonDashboardRepository jsonDashboardRepository,
                                        IPersonGameRepository personGameRepository,
                                        IPersonRepository personRepository,
                                        IConfigurationRepository configurationRepository,
                                        IEmailSender emailSender)
        {
            _mapper = mapper;
            _PersonLotteryRepository = PersonLotteryRepository;
            _LotteryRepository = lotteryRepository;
            _eventStoreRepository = eventStoreRepository;
            Bus = bus;

            _jsonDashboardRepository = jsonDashboardRepository;
            _personGameRepository = personGameRepository;
            _personRepository = personRepository;
            _configurationRepository = configurationRepository;

            _emailSender = emailSender;
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
            {
                lottery = _jsonDashboardRepository.GetFunctionJsonDashBoard(_LotteryRepository.GetLast().Concurse);
            }

            return new { concurse = lottery, personGame = "", amount_tickets = 0 };
        }

        internal List<PersonGame> PersonGame(out decimal amount, int concurse = 0, Guid? personId = null)
        {
            List<PersonGame> _personGame = new List<PersonGame>();
            Configuration configuration = _configurationRepository.GetFirst();

            if (concurse == 0)
                concurse = _LotteryRepository.GetLast().Concurse;

            if (personId != null)
            {
                _LotteryRepository.SetProcedureSP_CHECK_GAME(concurse, (Guid)personId);
                _personGame = _personGameRepository.GetFunctionJogoPessoa((Guid)personId, concurse, configuration.Calcular_Dezenas_Sem_Pontuacao).ToList();
            }
            else
            {
                _LotteryRepository.SetProcedureSP_CHECK_GAME(concurse);
                _personGame = _personGameRepository.GetFunctionJogosConcurso(concurse, configuration.Calcular_Dezenas_Sem_Pontuacao).ToList();
            }

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

        public Object SendEmail(int concurse = 0)
        {
            Lottery lottery = new Lottery();
            List<Person> pessoas = new List<Person>();
            Configuration configuration = _configurationRepository.GetFirst();

            if (concurse == 0)
                concurse = _LotteryRepository.GetLast().Concurse;

            lottery = _LotteryRepository.GetByConcurse(concurse);

            List<PersonGame> personGame = _personGameRepository.GetFunctionJogosConcurso(concurse, configuration.Calcular_Dezenas_Sem_Pontuacao, configuration.Valor_Minimo_Para_Envio_Email).ToList();
            foreach (var pes in personGame)
            {
                Person pessoa = _personRepository.GetById(pes.PesId);
                if (!pessoas.Contains(pessoa))
                    pessoas.Add(pessoa);
            }

            var assunto = "Lotofácil - Diego Galante";
            var corpoEmail = "";
            decimal total_bilhetes = 0;

            //Configuração de enviar email exclusivo para pessoa
            if (true)
            {
                foreach (var pessoa in pessoas)
                {
                    total_bilhetes = personGame.Where(x => x.PesId == pessoa.Id).Sum(x => x.Ticket_Amount);

                    List<PersonGame> pesGame = _personGameRepository.GetFunctionJogoPessoa(pessoa.Id, lottery.Concurse, configuration.Calcular_Dezenas_Sem_Pontuacao, configuration.Valor_Minimo_Para_Envio_Email).ToList();
                    corpoEmail = MontaHtml(lottery, pesGame);
                    _emailSender.SendEmailJogosPessoa(pessoa.Email, corpoEmail, assunto);
                    
                    total_bilhetes = 0;
                    corpoEmail = string.Empty;
                }
            }
            else
            {
                //Basicamente aqui todo mundo que registrou jogo recebe o email com os nomes, apostas e acertos de todos.
                //Não vou manter isso aqui, só mesmo pra teste e debug ;D
                total_bilhetes = personGame.Sum(x => x.Ticket_Amount);
                corpoEmail = MontaHtml(lottery, personGame);
                foreach (var pessoa in pessoas)
                    _emailSender.SendEmailJogosPessoa(Credenciais.EMAIL_ADM, corpoEmail, assunto);
                //_emailSender.SendEmailJogosPessoa(pessoa.Email, corpoEmail, assunto);

                total_bilhetes = 0;
                corpoEmail = string.Empty;
            }

            return new { ret = true, msg = "" };
        }


        internal string MontaHtml(Lottery lottery, List<PersonGame> jogosPessoas)
        {
            string abreHtml = string.Empty;
            string fechaHtml = string.Empty;
            string abreBody = string.Empty;
            string fechaBody = string.Empty;
            string abreTable = string.Empty;
            string fechaTable = string.Empty;
            string abreTH = string.Empty;
            string abreTHColspan = string.Empty;
            string fechaTH = string.Empty;
            string colspanNumero = string.Empty;
            string abreTR = string.Empty;
            string fechaTR = string.Empty;
            string htmlFinal = string.Empty;
            int cont = 1;

            string[] headerTeable = new string[] {
                "#",
                "ID",
                "Acertos",
                "Jogo",
                "Autor",
                "Valor Arrecadado"
            };

            abreHtml = @"<!DOCTYPE html>
                        <html>
                        <head>
                        <style>
                            table {
                            border: 1px solid black;
                            border - collapse: collapse;
                            width: 100 %;
                            }
                            th, td {
                                border: 1px solid grey;
                                border - collapse: collapse;
                                padding: 5px;
                                text - align: justify;
                            }
                            /*tr:nth-child(even) {
                                background-color: #dddddd;
                            }*/
                        </style>
                        </head> ";

            fechaHtml = "</html>";

            abreBody = "<body>";
            fechaBody = "</body>";

            abreTable = "<table>";
            fechaTable = "</table>";

            abreTR = "<tr>";
            fechaTR = "</tr>";

            string abreTD = "<td>";
            string fechaTD = "</td>";

            abreTH = "<th>";
            colspanNumero = headerTeable.Count().ToString();
            abreTHColspan = "<th colspan='" + colspanNumero + "'>";
            fechaTH = "</th>";

            //INICIA O HTML
            htmlFinal += abreHtml;
            htmlFinal += abreBody;

            //INICIA A TABELA
            htmlFinal += abreTable;

            //PRIMEIRA LINHA
            htmlFinal += abreTR;

            colspanNumero = (headerTeable.Count() - 1).ToString();
            abreTHColspan = "<th colspan='" + colspanNumero + "'>";
            htmlFinal += abreTHColspan;
            htmlFinal += string.Format("Concurso: {0}", lottery.Concurse);
            htmlFinal += fechaTH;

            htmlFinal += abreTH;
            htmlFinal += lottery.DtConcurse.ToShortDateString();
            htmlFinal += fechaTH;

            htmlFinal += fechaTR;

            htmlFinal += abreTR;
            colspanNumero = headerTeable.Count().ToString();
            abreTHColspan = "<th colspan='" + colspanNumero + "' style='text-align:center;'>";
            htmlFinal += abreTHColspan;
            htmlFinal += lottery.Game;
            htmlFinal += fechaTH;
            htmlFinal += fechaTR;

            #region HEADER Tabela
            htmlFinal += abreTR;
            foreach (var coluna in headerTeable)
            {
                htmlFinal += abreTH;
                htmlFinal += coluna;
                htmlFinal += fechaTH;
            }

            htmlFinal += fechaTR;
            #endregion FIM HEADER Tabela


            #region MIOLODATABELA
            decimal valorBilhetes = 0;
            if (jogosPessoas.Count > 0)
            {
                foreach (var acerto in jogosPessoas)
                {
                    htmlFinal += abreTR;

                    htmlFinal += "<th style='text-align:center;'>";
                    htmlFinal += cont++;
                    htmlFinal += fechaTH;

                    htmlFinal += abreTH;
                    htmlFinal += string.Format("{0}", acerto.Id);
                    htmlFinal += fechaTH;

                    htmlFinal += "<th style='text-align:center;'>";
                    htmlFinal += string.Format("{0}", acerto.Hits);
                    htmlFinal += fechaTH;

                    htmlFinal += abreTH;
                    htmlFinal += DestacaNumero(lottery.Game, acerto.Game);
                    htmlFinal += fechaTH;

                    htmlFinal += abreTH;
                    htmlFinal += acerto.Name;
                    htmlFinal += fechaTH;

                    htmlFinal += "<th style='text-align:center;'>";

                    switch (acerto.Hits)
                    {
                        case 11:
                            htmlFinal += lottery.Shared11.ToString("N");
                            break;
                        case 12:
                            htmlFinal += lottery.Shared12.ToString("N");
                            break;
                        case 13:
                            htmlFinal += lottery.Shared13.ToString("N");
                            break;
                        case 14:
                            htmlFinal += lottery.Shared14.ToString("N");
                            break;
                        case 15:
                            htmlFinal += lottery.Shared15.ToString("N");
                            break;
                        default:
                            htmlFinal += 0.ToString("N");
                            break;
                    }

                    valorBilhetes += acerto.Ticket_Amount;

                    htmlFinal += fechaTH;
                    htmlFinal += fechaTR;
                }
            }
            #endregion FIM MIOLODATABELA
            else
            {
                htmlFinal += abreTR;
                colspanNumero = "5";
                abreTHColspan = "<th colspan='" + colspanNumero + "' style='text-align:center;'>";
                htmlFinal += abreTHColspan;
                htmlFinal += "Não há jogos válidos de acordo com sua configuração. <br/> <span style='text-decoration: underline;'> Verifique a configuração: <span style='color:red;'>\"Valor mínimo do bilhete para o envio de e-mail\"</span>, para carregar os jogos no e-mail. </span>";
                htmlFinal += fechaTH;
            }

            #region Footer Tabela
            htmlFinal += abreTR;
            colspanNumero = (headerTeable.Count() - 1).ToString();
            abreTHColspan = "<th colspan='" + colspanNumero + "' style='text-align:right;'>";
            htmlFinal += abreTHColspan;
            htmlFinal += "Quantidade a receber dos bilhetes (R$)";
            htmlFinal += fechaTH;

            htmlFinal += "<th style='text-align:center; font-size:18px;'>";

            htmlFinal += valorBilhetes.ToString("N");
            htmlFinal += fechaTH;
            htmlFinal += fechaTR;
            #endregion FIM Footer Tabela

            htmlFinal += fechaTable;
            htmlFinal += fechaBody;
            htmlFinal += fechaHtml;

            return htmlFinal;
        }

        internal string DestacaNumero(string jogoSorteado, string jogoGerado)
        {
            string abreIns = string.Empty, fechaIns = string.Empty;
            string colorRed = "red";
            string retorno = string.Empty;

            abreIns = "<ins style='color:" + colorRed + "'>";
            fechaIns = "</ins>";
            bool achou = false;

            string[] jogoGeradoSpit = jogoGerado.Split('-');

            string[] jogoSorteadoSplit = jogoSorteado.Split('-');

            for (int j = 0; j < jogoGeradoSpit.Length; j++)
            {
                for (int i = 0; i < jogoSorteadoSplit.Length; i++)
                {
                    achou = false;
                    if (jogoGeradoSpit[j] == jogoSorteadoSplit[i])
                    {
                        achou = true;
                        if (j < jogoGeradoSpit.Length - 1)
                            retorno += abreIns + jogoGeradoSpit[j] + fechaIns + "-";
                        else
                            retorno += abreIns + jogoGeradoSpit[j] + fechaIns;
                        break;
                    }
                }

                if (!achou)
                {
                    if (j < jogoSorteadoSplit.Length - 1)
                        retorno += jogoGeradoSpit[j] + "-";
                    else
                        retorno += jogoGeradoSpit[j];
                }
            }

            return retorno;
        }
    }
}
