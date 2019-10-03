using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoteriaFacil.Infra.CrossCutting.Util
{
    public static class Util
    {
        [System.Runtime.InteropServices.DllImport("wininet.dll")]
        private extern static Boolean InternetGetConnectedState(out int Description, int ReservedValue);

        /// <summary>
        /// Checa a conexão.
        /// </summary>
        /// <returns></returns>
        public static bool IsConnected()
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
        public static string DataPorExtenso(DateTime? dataExtenso)
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
        public static string FormataString(string mascara, string valor)
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
        public static string GetTokenOnline()
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
        public static IEnumerable<string> OrganizaJogo(string jogoJson)
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
        public static string OrdenaDezenas(string dezenas)
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
        public static string FormataDezena(string dezenaString)
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

    }
}
