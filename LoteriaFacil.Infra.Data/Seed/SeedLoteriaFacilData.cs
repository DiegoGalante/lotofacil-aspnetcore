using LoteriaFacil.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using LoteriaFacil.Domain.Models;
using System.IO;
using LoteriaFacil.Infra.CrossCutting.Util;
using Microsoft.EntityFrameworkCore;

namespace LoteriaFacil.Infra.Data.Seed
{
    public static class SeedLoteriaFacilData
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<LoteriaFacilContext>();
            context.Database.EnsureCreated();

            if (!context.TypeLottery.Any())
            {
                context.TypeLottery.Add(new TypeLottery { Name = "Loto Fácil", Tens_Min = 15, Bet_Min = (decimal)2.50, Hit_Min = 11, Hit_Max = 15 });
                context.SaveChanges();
            }

            if (!context.Configuration.Any())
            {
                context.Configuration.Add(new Configuration { Calcular_Dezenas_Sem_Pontuacao = true, Enviar_Email_Manualmente = true, Enviar_Email_Automaticamente = false, Checar_Jogo_Online = false, Valor_Minimo_Para_Envio_Email = (decimal)4.00 });
                context.SaveChanges();
            }

            if (!context.Lottery.Any())
                SeedLotteryData(context);

            try
            {
                if (!context.JsonDashboard.Any())
                    context.Database.ExecuteSqlCommand("drop table JsonDashboard");
            }
            catch (Exception ex)
            {

                
            }

            try
            {

                if (!context.PersonGame.Any())
                    context.Database.ExecuteSqlCommand("drop table PersonGame");
            }
            catch (Exception ex)
            {

               
            }


            SeedFunctions.Seed(context);
            SeedProcedures.Seed(context);
        }

        internal static void SeedLotteryData(LoteriaFacilContext context)
        {
            string caminhoPadrao = Directory.GetCurrentDirectory();

            string caminhoArquivo = Directory.GetCurrentDirectory().Remove(caminhoPadrao.LastIndexOf("\\"));
            string caminho = caminhoArquivo + @"\lotofacilDados.txt";
            //string caminho =lotofacil;

            /*
             Estrutura do Arquivo:
             0 - Num do Concurso
             1 - Data Concurso
             2~16 - Dezenas
             17 - Qtde de Pessoas 15 Acertos
             18 - Qtde de Pessoas 14 Acertos
             19 - Qtde de Pessoas 13 Acertos
             20 - Qtde de Pessoas 12 Acertos
             21 - Qtde de Pessoas 11 Acertos
             22 - Valor Rateio 15 Acertos
             23 - Valor Rateio 14 Acertos
             24 - Valor Rateio 13 Acertos
             25 - Valor Rateio 12 Acertos
             26 - Valor Rateio 11 Acertos
             */
            TypeLottery tpl = context.TypeLottery.FirstOrDefault();

            if (tpl != null && File.Exists(caminho))
            {
                var texto = string.Empty;
                List<string> inserts = new List<string>();
                StreamReader _strm = new StreamReader(caminho);

                while (!_strm.EndOfStream)
                {
                    DateTime dataConcurso;
                    string concurso;
                    string dezenas;

                    string qtdePesosas15Acertos;
                    string qtdePesosas14Acertos;
                    string qtdePesosas13Acertos;
                    string qtdePesosas12Acertos;
                    string qtdePesosas11Acertos;

                    string valorRateio15Acertos;
                    string valorRateio14Acertos;
                    string valorRateio13Acertos;
                    string valorRateio12Acertos;
                    string valorRateio11Acertos;

                    string linha = _strm.ReadLine();
                    string[] vet;
                    if (!string.IsNullOrEmpty(linha))
                    {
                        vet = linha.Split('|');
                        if (vet.Length == 27 || vet.Length == 26 || vet.Length == 28)
                        {
                            if (vet[1] != "")
                            {
                                concurso = vet[0];
                                dataConcurso = Convert.ToDateTime(vet[1]);

                                if (vet[2].Length == 1)
                                    vet[2] = 0 + vet[2];

                                if (vet[3].Length == 1)
                                    vet[3] = 0 + vet[3];

                                if (vet[4].Length == 1)
                                    vet[4] = 0 + vet[4];

                                if (vet[5].Length == 1)
                                    vet[5] = 0 + vet[5];

                                if (vet[6].Length == 1)
                                    vet[6] = 0 + vet[6];

                                if (vet[7].Length == 1)
                                    vet[7] = 0 + vet[7];

                                if (vet[8].Length == 1)
                                    vet[8] = 0 + vet[8];

                                if (vet[9].Length == 1)
                                    vet[9] = 0 + vet[9];

                                if (vet[10].Length == 1)
                                    vet[10] = 0 + vet[10];

                                if (vet[11].Length == 1)
                                    vet[11] = 0 + vet[11];

                                if (vet[12].Length == 1)
                                    vet[12] = 0 + vet[12];

                                if (vet[13].Length == 1)
                                    vet[13] = 0 + vet[13];

                                if (vet[14].Length == 1)
                                    vet[14] = 0 + vet[14];

                                if (vet[15].Length == 1)
                                    vet[15] = 0 + vet[15];

                                if (vet[16].Length == 1)
                                    vet[16] = 0 + vet[16];

                                dezenas = vet[2] + "-" + vet[3] + "-" + vet[4] + "-" + vet[5] + "-" + vet[6] + "-" + vet[7] + "-" + vet[8] + "-" + vet[9] + "-" + vet[10] + "-" + vet[11] + "-" + vet[12] + "-" + vet[13] + "-" + vet[14] + "-" + vet[15] + "-" + vet[16];

                                qtdePesosas15Acertos = vet[17];
                                qtdePesosas14Acertos = vet[18];
                                qtdePesosas13Acertos = vet[19];
                                qtdePesosas12Acertos = vet[20];
                                qtdePesosas11Acertos = vet[21];

                                valorRateio15Acertos = vet[22];
                                valorRateio14Acertos = vet[23];
                                valorRateio13Acertos = vet[24];
                                valorRateio12Acertos = vet[25];
                                valorRateio11Acertos = vet[26];


                                var Acertos = new
                                {
                                    Hits15 = Convert.ToInt32(qtdePesosas15Acertos.ToString()),
                                    Shared15 = Convert.ToDecimal(valorRateio15Acertos.ToString()),

                                    Hits14 = Convert.ToInt32(qtdePesosas14Acertos.ToString()),
                                    Shared14 = Convert.ToDecimal(valorRateio14Acertos.ToString()),

                                    Hits13 = Convert.ToInt32(qtdePesosas13Acertos.ToString()),
                                    Shared13 = Convert.ToDecimal(valorRateio13Acertos.ToString()),

                                    Hits12 = Convert.ToInt32(qtdePesosas12Acertos.ToString()),
                                    Shared12 = Convert.ToDecimal(valorRateio12Acertos.ToString()),

                                    Hits11 = Convert.ToInt32(qtdePesosas11Acertos.ToString()),
                                    Shared11 = Convert.ToDecimal(valorRateio11Acertos.ToString()),
                                };

                                Lottery lottery = new Lottery()
                                {
                                    Concurse = int.Parse(concurso),
                                    DtConcurse = dataConcurso,
                                    Game = Util.OrdenaDezenas(dezenas),
                                    Hit15 = Acertos.Hits15,
                                    Hit14 = Acertos.Hits14,
                                    Hit13 = Acertos.Hits13,
                                    Hit12 = Acertos.Hits12,
                                    Hit11 = Acertos.Hits11,
                                    Shared15 = Acertos.Shared15,
                                    Shared14 = Acertos.Shared14,
                                    Shared13 = Acertos.Shared13,
                                    Shared12 = Acertos.Shared12,
                                    Shared11 = Acertos.Shared11,
                                    DtNextConcurse = dataConcurso.DayOfWeek == DayOfWeek.Friday ? dataConcurso.AddDays(3) : dataConcurso.AddDays(2),
                                    TypeLotteryId = tpl.Id
                                };

                                context.Lottery.Add(lottery);
                            }
                        }
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
