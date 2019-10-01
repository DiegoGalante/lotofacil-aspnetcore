using AutoMapper;
using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Domain.Core.Bus;
using LoteriaFacil.Domain.Interfaces;
using LoteriaFacil.Domain.Models;
using LoteriaFacil.Infra.Data.Repository.EventSourcing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoteriaFacil.Application.Services
{
    public class UtilitiesAppService : IUtilitiesAppService
    {
        private readonly IMapper _mapper;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly ILotteryRepository _lotteryRepository;
        private readonly IMediatorHandler Bus;

        public UtilitiesAppService(IMapper mapper,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository,
                                  ILotteryRepository lotteryRepository)
        {
            _mapper = mapper;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
            _lotteryRepository = lotteryRepository;
        }

        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static Boolean InternetGetConnectedState(out int Description, int ReservedValue);

        /// <summary>
        /// Checa a conexão.
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            int Description;
            return InternetGetConnectedState(out Description, 0);
        }

        /// <summary>
        /// 0- Segunda-Feira
        /// 1- Terça-Feira
        /// 2- Quarta-Feira
        /// 3- Quinta-Feira
        /// 4- Sexta-Feira
        /// 5- Sábado
        /// 6 - Domingo
        /// </summary>
        /// <returns>
        /// Retorna a data atual por extenso. Exemplo: Segunda-Feira, 10 de Agosto de 2019.
        /// </returns>
        public string DataPorExtenso(DateTime? dataExtenso)
        {
            string data = "", mesporExtenso = "";
            DateTime? dataConverter = dataExtenso.HasValue ? dataExtenso : DateTime.Now;

            byte mesNumero = (byte)Convert.ToDateTime(dataConverter).Month;
            short ano = (short)Convert.ToDateTime(dataConverter).Year;
            byte mes = (byte)Convert.ToDateTime(dataConverter).Month, diaMes = (byte)Convert.ToDateTime(dataConverter).Day;

            #region Dia da semana por extenso
            //DayOfWeek diadasemana = DateTime.Now.DayOfWeek;
            switch (Convert.ToDateTime(dataConverter).DayOfWeek)
            {
                case DayOfWeek.Monday:
                    data = "Segunda-Feira";
                    break;
                case DayOfWeek.Tuesday:
                    data = "Terça-Feira";
                    break;
                case DayOfWeek.Wednesday:
                    data = "Quarta-Feira";
                    break;
                case DayOfWeek.Thursday:
                    data = "Quinta-Feira";
                    break;
                case DayOfWeek.Friday:
                    data = "Sexta-Feira";
                    break;
                case DayOfWeek.Saturday:
                    data = "Sábado";
                    break;
                case DayOfWeek.Sunday:
                    data = "Domingo";
                    break;
            }
            #endregion

            #region Mes do ano por extenso
            switch (mes)
            {
                case 1:
                    mesporExtenso = "Janeiro";
                    break;
                case 2:
                    mesporExtenso = "Fevereiro";
                    break;
                case 3:
                    mesporExtenso = "Março";
                    break;
                case 4:
                    mesporExtenso = "Abril";
                    break;
                case 5:
                    mesporExtenso = "Maio";
                    break;
                case 6:
                    mesporExtenso = "Junho";
                    break;
                case 7:
                    mesporExtenso = "Julho";
                    break;
                case 8:
                    mesporExtenso = "Agosto";
                    break;
                case 9:
                    mesporExtenso = "Setembro";
                    break;
                case 10:
                    mesporExtenso = "Outubro";
                    break;
                case 11:
                    mesporExtenso = "Novembro";
                    break;
                case 12:
                    mesporExtenso = "Dezembro";
                    break;
            }
            #endregion

            if (data != "")
                //data = string.Format("{0}, {1} de {2} de {3}", data, diaMes, mesporExtenso, ano);
                data += ", " + diaMes + " de " + mesporExtenso + " de " + ano;

            return data.Trim();
        }

        /// <summary>
        /// Formata a string de acordo com a mascara passada por parâmetro.
        /// </summary>
        /// <param name="mascara"></param>
        /// <param name="valor"></param>
        /// <returns>
        /// Exemplo: mascara:#####-###, string:00000000 = resultado: 00000-000
        /// </returns>
        public string FormataString(string mascara, string valor)
        {
            string novoValor = string.Empty;
            int posicao = 0;

            for (int i = 0; mascara.Length > i; i++)
            {
                if (Convert.ToString(mascara[i]) == "#")
                {
                    if (valor.Length > posicao)
                    {
                        novoValor = novoValor + valor[posicao];
                        posicao++;
                    }
                    else
                        break;
                }
                else
                {
                    if (valor.Length > posicao)
                        novoValor = novoValor + mascara[i];
                    else
                        break;
                }
            }
            return novoValor;
        }

        /// <summary>
        /// Retorna um token válido para utilizar na recuperação do jogo online. 
        /// >>>>>> INFELIZMENTE ESTÁ DEPRECIADO, MUDARAM A ESTRUTURA E DEIXOU DE FUNCIONAR. <<<<<<
        /// </summary>
        /// <returns></returns>
        public string GetTokenOnline()
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            string titulo;

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                string html = client.DownloadString("https://confiraloterias.com.br/api/lotofacil/");
                doc.LoadHtml(html);
            }

            //Titulo
            HtmlAgilityPack.HtmlNode no = doc.DocumentNode.SelectSingleNode("//div[@id='exemplo_json']/p/a");
            return titulo = no.InnerText.Split('=')[no.InnerText.Split('=').Count() - 1];
        }

        /// <summary>
        /// Retorna o jogo organizado.
        /// </summary>
        /// <param name="jogoJson"></param>
        /// <param name="tipoJogo"></param>
        /// <returns>
        /// Exemplo: 00-00-00-00-00-00-00-00-00-00-00-00
        /// </returns>
        public IEnumerable<string> OrganizaJog(string jogoJson, string tipoJogo)
        {
            List<List<string>> jogos = new List<List<string>>();
            List<string> jogo = new List<string>();
            List<string> resultado = new List<string>();
            string jogo1 = "";

            #region LotoFacil
            for (int l = 0; l < 15; l++)
            {
                jogo.Add(jogoJson);

                if (jogo.Count == 15)
                {
                    jogos.Add(jogo);
                    while (jogo1.Length != 44)
                    {
                        for (int i = 0; i < jogo.Count; i++)
                        {
                            if (jogo1 == "")
                            {
                                if (jogo[i].ToString().Trim().Length == 1)
                                    jogo1 += "0" + jogo[i].ToString().Trim();
                                else
                                    jogo1 += jogo[i].ToString().Trim();
                            }
                            else if (jogo1.Length % 2 == 0)
                            {
                                if (jogo[i].ToString().Trim().Length == 1)
                                    jogo1 += "-0" + jogo[i].ToString().Trim();
                                else
                                    jogo1 += "-" + jogo[i].ToString().Trim();
                            }
                            else
                            {
                                if (jogo[i].ToString().Trim().Length == 1)
                                    jogo1 += "-0" + jogo[i].ToString().Trim();
                                else
                                    jogo1 += "-" + jogo[i].ToString().Trim();
                            }
                        }
                        jogo.Clear();
                    }
                }
            }

            resultado.Add(jogo1);
            jogo1 = "";
            #endregion LotoFacil

            return resultado;
        }

        /// <summary>
        /// Realiza a ordenação das dezenas.
        /// </summary>
        /// <param name="dezenas"></param>
        /// <returns>
        /// Exemplo: 09-03-01 -> 01-03-09
        /// </returns>
        public string OrdenaDezenas(string dezenas)
        {
            string retorno = string.Empty;
            string[] aux = dezenas.Split('-');
            List<int> vetInteiros = new List<int>();

            for (int i = 0; i < aux.Count(); i++)
                if (aux[i].Trim() != string.Empty && Convert.ToByte(aux[i]) > 0)
                    vetInteiros.Add(Convert.ToByte(aux[i]));

            int[] vetInteirosOrdenadoCrescente = vetInteiros.OrderBy(x => x).ToArray();
            //int[] vetInteirosOrdenadoDecrescente = vetInteiros.OrderByDescending(x => x).ToArray();

            for (int i = 0; i < vetInteirosOrdenadoCrescente.Count(); i++)
            {
                if (i == vetInteirosOrdenadoCrescente.Count() - 1)
                    retorno += FormataDezena(vetInteirosOrdenadoCrescente[i].ToString());
                else
                    retorno += FormataDezena(vetInteirosOrdenadoCrescente[i].ToString()) + "-";
            }


            return retorno;
        }

        /// <summary>
        /// Formata a dezena de 1 a 9 no padrão 00.
        /// </summary>
        /// <param name="dezenaString"></param>
        /// <returns>
        /// Exemplo: 1 -> 01
        /// </returns>
        public string FormataDezena(string dezenaString)
        {
            int dezena = 0;
            int.TryParse(dezenaString, out dezena);
            string retorno = string.Empty;

            switch (dezena)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    retorno = "0" + dezena.ToString().Trim();
                    break;
                default:
                    retorno = dezena.ToString();
                    break;
            }

            return retorno;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string MontaHtml(Dictionary<PersonLottery, byte> acertosDicionario, List<Person> pessoas, PersonLottery jsonData, decimal qtdeTotalARecolher)
        {
            //throw new NotImplementedException();

            Lottery lottery = _lotteryRepository.GetByConcurse(jsonData.Concurse);

            #region Terminar
            string abreHtml = string.Empty, fechaHtml = string.Empty;
            string abreBody = string.Empty, fechaBody = string.Empty;
            string abreTable = string.Empty, fechaTable = string.Empty;
            string abreTH = string.Empty, abreTHColspan = string.Empty, fechaTH = string.Empty;
            string colspanNumero = string.Empty;
            string abreTD = string.Empty, fechaTD = string.Empty;
            string abreTR = string.Empty, fechaTR = string.Empty;
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
                            border-collapse: collapse;
                            width: 100%;
                        }
                        th, td {
                            border: 1px solid grey;
                            border-collapse: collapse;
                            padding: 5px;
                            text-align: justify;    
                        }
                        tr:nth-child(even) {
                            background-color: #dddddd;
                        }
                        </style>
                        </head>";

            fechaHtml = "</html>";

            abreBody = "<body>";
            fechaBody = "</body>";

            abreTable = "<table>";
            fechaTable = "</table>";

            abreTR = "<tr>";
            fechaTR = "</tr>";

            abreTD = "<td>";
            fechaTD = "</td>";

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
            htmlFinal += "Concurso: " + jsonData.Concurse;
            htmlFinal += fechaTH;

            htmlFinal += abreTH;
            htmlFinal += lottery.DtConcurse;
            htmlFinal += fechaTH;

            htmlFinal += fechaTR;

            htmlFinal += abreTR;
            colspanNumero = headerTeable.Count().ToString();
            abreTHColspan = "<th colspan='" + colspanNumero + "' style='text-align:center;'>";
            htmlFinal += abreTHColspan;
            htmlFinal += lottery.Game;
            htmlFinal += fechaTH;
            htmlFinal += fechaTR;



            // HEADER Tabela
            htmlFinal += abreTR;
            foreach (var coluna in headerTeable)
            {
                htmlFinal += abreTH;
                htmlFinal += coluna;
                htmlFinal += fechaTH;
            }
            htmlFinal += fechaTR;
            // FIM HEADER Tabela


            //MIOLODATABELA
            foreach (var acerto in acertosDicionario)
            {
                htmlFinal += abreTR;

                htmlFinal += "<th style='text-align:center;'>";
                htmlFinal += cont++;
                htmlFinal += fechaTH;

                htmlFinal += abreTH;
                htmlFinal += acerto.Key.Concurse;
                htmlFinal += fechaTH;

                htmlFinal += "<th style='text-align:center;'>";
                htmlFinal += acerto.Value;
                htmlFinal += fechaTH;

                htmlFinal += abreTH;
                htmlFinal += DestacaNumero(lottery.Game, acerto.Key.Game);
                htmlFinal += fechaTH;

                htmlFinal += abreTH;
                htmlFinal += acerto.Key.Person.Name;
                htmlFinal += fechaTH;

                htmlFinal += "<th style='text-align:center;'>";
                switch (acerto.Value)
                {
                    case 11:
                        htmlFinal += Convert.ToDecimal(jsonData.Ticket_Amount).ToString("N");
                        break;
                    case 12:
                        htmlFinal += Convert.ToDecimal(jsonData.Ticket_Amount).ToString("N");
                        break;
                    case 13:
                        htmlFinal += Convert.ToDecimal(jsonData.Ticket_Amount).ToString("N");
                        break;
                    case 14:
                        htmlFinal += Convert.ToDecimal(jsonData.Ticket_Amount).ToString("N");
                        break;
                    case 15:
                        htmlFinal += Convert.ToDecimal(jsonData.Ticket_Amount).ToString("N");
                        break;
                    default:
                        htmlFinal += "0,00";
                        break;
                }
                htmlFinal += fechaTH;

                htmlFinal += fechaTR;
            }
            //FIM MIOLODATABELA


            //Footer Tabela
            htmlFinal += abreTR;
            colspanNumero = (headerTeable.Count() - 1).ToString();
            abreTHColspan = "<th colspan='" + colspanNumero + "' style='text-align:right;'>";
            htmlFinal += abreTHColspan;
            htmlFinal += "Quantidade a receber dos bilhetes (R$)";
            htmlFinal += fechaTH;

            htmlFinal += "<th style='text-align:center; font-size:19px;'>";
            htmlFinal += qtdeTotalARecolher > 0 ? qtdeTotalARecolher.ToString("N") : "0,00";
            htmlFinal += fechaTH;
            htmlFinal += fechaTR;
            // FIM Footer Tabela

            htmlFinal += fechaTable;
            htmlFinal += fechaBody;
            htmlFinal += fechaHtml;


            return htmlFinal;
            #endregion Terminar
        }

        public string MontaHtml(Lottery lottery, List<PersonGame> jogosPessoas)
        {
            string abreHtml = "";
            string fechaHtml = "";
            string abreBody = "";
            string fechaBody = "";
            string abreTable = "";
            string fechaTable = "";
            string abreTH = "";
            string abreTHColspan = "";
            string fechaTH = "";
            string colspanNumero = "";
            string abreTR = "";
            string fechaTR = "";
            string htmlFinal = "";

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
            colspanNumero = "5";
            abreTHColspan = "<th colspan='" + colspanNumero + "'>";
            fechaTH = "</th>";

            //INICIA O HTML
            htmlFinal += abreHtml;
            htmlFinal += abreBody;

            //INICIA A TABELA
            htmlFinal += abreTable;

            //PRIMEIRA LINHA
            htmlFinal += abreTR;

            colspanNumero = "4";
            abreTHColspan = "<th colspan='" + colspanNumero + "'>";
            htmlFinal += abreTHColspan;
            htmlFinal += string.Format("Concurso: {0}", lottery.Concurse);
            htmlFinal += fechaTH;

            htmlFinal += abreTH;
            htmlFinal +=
            htmlFinal += fechaTH;

            htmlFinal += fechaTR;

            htmlFinal += abreTR;
            colspanNumero = "5";
            abreTHColspan = "<th colspan='" + colspanNumero + "' style='text-align:center;'>";
            htmlFinal += abreTHColspan;
            htmlFinal += lottery.Game;
            htmlFinal += fechaTH;
            htmlFinal += fechaTR;

            string[] headerTeable = {
                        "ID",
                        "Acertos",
                        "Jogo",
                        "Autor",
                        "Valor Arrecadado"
            };

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


                    if (acerto.Hits == 11)
                    {
                        htmlFinal += lottery.Shared11.ToString("N");
                        valorBilhetes += acerto.Ticket_Amount;
                    }
                    else if (acerto.Hits == 12)
                    {
                        htmlFinal += lottery.Shared12.ToString("N");
                        valorBilhetes += acerto.Ticket_Amount;
                    }
                    else if (acerto.Hits == 13)
                    {
                        htmlFinal += lottery.Shared13.ToString("N");
                        valorBilhetes += acerto.Ticket_Amount;
                    }
                    else if (acerto.Hits == 14)
                    {
                        htmlFinal += lottery.Shared14.ToString("N");
                        valorBilhetes += acerto.Ticket_Amount;
                    }
                    else if (acerto.Hits == 15)
                    {
                        htmlFinal += lottery.Shared15.ToString("N");
                        valorBilhetes += acerto.Ticket_Amount;
                    }
                    else
                        htmlFinal += 0.ToString("N");

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
            colspanNumero = "4";
            abreTHColspan = "<th colspan='" + colspanNumero + "' style='text-align:right;'>";
            htmlFinal += abreTHColspan;
            htmlFinal += "Quantidade a receber dos bilhetes (R$)";
            htmlFinal += fechaTH;

            htmlFinal += "<th style='text-align:center; font-size:18px;'>";
            //htmlFinal += qtdeTotalARecolher > 0 ? qtdeTotalARecolher.To("N") : "0,00";

            htmlFinal += valorBilhetes.ToString("N");
            htmlFinal += fechaTH;
            htmlFinal += fechaTR;
            #endregion FIM Footer Tabela

            htmlFinal += fechaTable;
            htmlFinal += fechaBody;
            htmlFinal += fechaHtml;

            return htmlFinal;
        }

        public string DestacaNumero(string jogoSorteado, string jogoGerado)
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
