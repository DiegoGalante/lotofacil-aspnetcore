using LoteriaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoteriaFacil.Infra.Data.Seed
{
    public static class SeedFunctionJsonDashboard
    {
        public static void Seed(LoteriaFacilContext loteriaFacilContext)
        {
            var functionJsonDashBoard = @"CREATE FUNCTION [dbo].[jsonDashboard](@concurseID INT)  
                                            RETURNS TABLE  
                                            AS  
                                            RETURN   
                                            (  
	                                            --IF ISNULL(@concurseID,0) > 0
	                                            -- BEGIN
	                                            --		SELECT TOP 1 
	                                            --		 Concurse, 
	                                            --		 FORMAT(lot_dtConcurse, 'dd/MM/yyyy') as lot_dtConcurse,
	                                            --		 --FORMAT(lot_dtConcurse, 'dd/MM/yyyy hh:mm:ss'),
	                                            --		 dbo.INITCAP(FORMAT(lot_dtConcurse, 'D')) as 'data_extenso',
	                                            --		 lot_game,
	                                            --		 Hit15, Shared15, 
	                                            --		 (SELECT TOP 1 cast((Shared15*100/(SELECT TOP 1  Shared15 from Lottery 	WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as '_15Porcentagem',
	                                            --		 Hit14, Shared14,  
	                                            --		 (SELECT TOP 1 cast((Shared14*100/(SELECT TOP 1  Shared14 from Lottery 	WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as '_14Porcentagem',
	                                            --		 Hit13, Shared13,  
	                                            --		 (SELECT TOP 1 cast((Shared13*100/(SELECT TOP 1  Shared13 from Lottery 	WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as '_13Porcentagem',
	                                            --		 Hit12, Shared12,  
	                                            --		 (SELECT TOP 1 cast((Shared12*100/(SELECT TOP 1  Shared12 from Lottery 	WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as '_12Porcentagem',
	                                            --		 Hit11, Shared11,
	                                            --		 (SELECT TOP 1 cast((Shared11*100/(SELECT TOP 1  Shared11 from Lottery 	WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as '_11Porcentagem'
	                                            --	FROM Lottery
	                                            --		WHERE
	                                            --			tpj_id = 2 and Concurse = @concurseID
	                                            --	ORDER BY 1 DESC
	                                            --END
	                                            --ELSE
	                                            -- BEGIN

				                                            SELECT TOP 1
				                                             Id,
				                                             Concurse, 
				                                             FORMAT(DtConcurse, 'dd/MM/yyyy') as DtConcurse,
				                                             --FORMAT(lot_dtConcurse, 'dd/MM/yyyy hh:mm:ss'),
				                                             dbo.INITCAP(FORMAT(DtConcurse, 'D')) as 'DtExtense',
				                                             Game,
				                                             Hit15, Shared15, 
				                                             (SELECT TOP 1 cast((ISNULL(Shared15, 100)*100/ISNULL((SELECT TOP 1  CASE WHEN Shared15 = 0 THEN 100 ELSE Shared15 END   from Lottery WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc), 100) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as 'Percent15',
				                                             Hit14, Shared14,  
				                                             (SELECT TOP 1 cast((Shared14*100/(SELECT TOP 1  Shared14 from Lottery 	WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as 'Percent14',
				                                             Hit13, Shared13,  
				                                             (SELECT TOP 1 cast((Shared13*100/(SELECT TOP 1  Shared13 from Lottery 	WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as 'Percent13',
				                                             Hit12, Shared12,  
				                                             (SELECT TOP 1 cast((Shared12*100/(SELECT TOP 1  Shared12 from Lottery 	WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as 'Percent12',
				                                             Hit11, Shared11,
				                                             (SELECT TOP 1 cast((Shared11*100/(SELECT TOP 1  Shared11 from Lottery 	WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as 'Percent11'
				                                            FROM Lottery
				                                            WHERE
					                                            TypeLotteryId = (select top 1 Id from TypeLottery)
					                                            and Concurse = @concurseID
				                                            ORDER BY 1 DESC
                                            --		END
                                            --END
                                            )";

            try
            {
                loteriaFacilContext.Database.ExecuteSqlCommand(functionJsonDashBoard);
            }
            catch (Exception ex)
            {


            }
        }
    }
}
