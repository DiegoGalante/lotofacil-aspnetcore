using LoteriaFacil.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using LoteriaFacil.Domain.Models;

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

            SeedFunctions.Seed(context);
            SeedProcedures.Seed(context);
        }
    }
}
