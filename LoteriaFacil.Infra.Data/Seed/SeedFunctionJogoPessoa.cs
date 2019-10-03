using LoteriaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Infra.Data.Seed
{
    public static class SeedFunctionJogoPessoa
    {
        public static void Seed(LoteriaFacilContext loteriaFacilContext)
        {
            var functionJogoPessoa = @"CREATE FUNCTION [dbo].[jogoPessoa] (@concurseID INT, @personId uniqueidentifier)  
                                        RETURNS TABLE  
                                        AS  
                                        RETURN   
                                        (  
		                                        SELECT  pl.Id, pl.Id as 'LotteryId', pl.Concurse, pes.Name as 'Name', pl.Game, pl.Hits, pl.Ticket_Amount as Ticket_Amount, pes.Id as 'PesId'
		                                        FROM PersonLottery pl
		                                        inner join Lottery lot on pl.LotteryId = lot.Id
		                                        inner join Person pes on pl.PersonId = pes.Id
		                                        WHERE lot.TypeLotteryId = (select top 1 Id from TypeLottery)
		                                        and pl.Concurse = @concurseID
		                                        and pl.PersonId = @personId
		                                        group by pl.Id, pl.Concurse, pes.Id, pes.Name, pl.Game, pl.Hits, pl.Ticket_Amount
	
                                        );";

            loteriaFacilContext.Database.ExecuteSqlCommand(functionJogoPessoa);
        }
    }
}
