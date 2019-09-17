USE [LoteriaFacil]
GO
/****** Object:  UserDefinedFunction [dbo].[jogoPessoa]    Script Date: 17/09/2019 18:43:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[jogoPessoa] (@concurseID INT)  
RETURNS TABLE  
AS  
RETURN   
(  
	select Name from Persons --apenas pra gravar a function

	--SELECT  pl.Id, pl.Concurse, pes.Name, pl.Game, pl.Hits, pl.Ticket_Amount as Ticket_Amount, pes.Id
	-- FROM Person_Lottery pl
	--inner join Lottery lot on pl.LotteryId = lot.Id
	--inner join Persons pes on pl.PersonId = pes.Id
	--WHERE lot.Type_LotteryId = '738E9B0D-73DE-4BAD-B49E-2B7828AC1C60' 
	--and Concurse = @concurseID
	----and pes.pes_id = 1
	--group by pl.Id, pl.Concurse, pes.Id, pes.Name, pl.Game, pl.Hits, pl.Ticket_Amount 

);

