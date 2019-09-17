USE [LoteriaFacil]
GO
/****** Object:  UserDefinedFunction [dbo].[jsonDashboard]    Script Date: 17/09/2019 18:44:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[jsonDashboard](@concurseID INT)  
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

	select top 1 * from Persons 
				--SELECT TOP 1 
				-- Concurse, 
				-- FORMAT(DtConcurse, 'dd/MM/yyyy') as DtConcurse,
				-- --FORMAT(lot_dtConcurse, 'dd/MM/yyyy hh:mm:ss'),
				-- dbo.INITCAP(FORMAT(DtConcurse, 'D')) as 'data_extenso',
				-- Game,
				-- Hit15, Shared15, 
				-- (SELECT TOP 1 cast((ISNULL(Shared15, 100)*100/ISNULL((SELECT TOP 1  CASE WHEN Shared15 = 0 THEN 100 ELSE Shared15 END   from Lottery WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc), 100) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as '_15Porcentagem',
				-- Hit14, Shared14,  
				-- (SELECT TOP 1 cast((Shared14*100/(SELECT TOP 1  Shared14 from Lottery 	WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as '_14Porcentagem',
				-- Hit13, Shared13,  
				-- (SELECT TOP 1 cast((Shared13*100/(SELECT TOP 1  Shared13 from Lottery 	WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as '_13Porcentagem',
				-- Hit12, Shared12,  
				-- (SELECT TOP 1 cast((Shared12*100/(SELECT TOP 1  Shared12 from Lottery 	WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as '_12Porcentagem',
				-- Hit11, Shared11,
				-- (SELECT TOP 1 cast((Shared11*100/(SELECT TOP 1  Shared11 from Lottery 	WHERE Concurse = (SELECT TOP 1 Concurse -1 from Lottery order by Concurse desc )	order by Concurse desc) - 100) as decimal(10,2)) from Lottery order by Concurse desc)  as '_11Porcentagem'
				--FROM Lottery
				--WHERE
				--	Type_LotteryId = '738E9B0D-73DE-4BAD-B49E-2B7828AC1C60'
				--	and Concurse = @concurseID
				--ORDER BY 1 DESC
--		END
--END
)  