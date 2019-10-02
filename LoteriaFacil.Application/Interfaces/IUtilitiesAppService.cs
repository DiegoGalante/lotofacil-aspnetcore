using LoteriaFacil.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Application.Interfaces
{
    public interface IUtilitiesAppService : IDisposable
    {
        /// <summary>
        /// Checa a conexão.
        /// </summary>
        /// <returns></returns>
        bool IsConnected();

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
        string DataPorExtenso(DateTime? dataExtenso);

        /// <summary>
        /// Formata a string de acordo com a mascara passada por parâmetro.
        /// </summary>
        /// <param name="mascara"></param>
        /// <param name="valor"></param>
        /// <returns>
        /// Exemplo: mascara:#####-###, string:00000000 = resultado: 00000-000
        /// </returns>
        string FormataString(string mascara, string valor);

        /// <summary>
        /// Retorna o jogo organizado.
        /// </summary>
        /// <param name="jogoJson"></param>
        /// <param name="tipoJogo"></param>
        /// <returns>
        /// Exemplo: 00-00-00-00-00-00-00-00-00-00-00-00
        /// </returns>
        IEnumerable<string> OrganizaJog(string jogoJson, string tipoJogo);

        /// <summary>
        /// Retorna um token válido para utilizar na recuperação do jogo online.
        /// </summary>
        /// <returns></returns>
        string GetTokenOnline();

        string OrdenaDezenas(string dezenas);

        string FormataDezena(string dezenaString);

        string MontaHtml(Lottery lottery, List<PersonGame> jogosPessoas);

        string DestacaNumero(string jogoSorteado, string jogoGerado);
    }
}
