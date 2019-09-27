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
	SELECT  pl.Id, pl.Id as 'LotteryId', pl.Concurse, pes.Name as 'Name', pl.Game, pl.Hits, pl.Ticket_Amount as Ticket_Amount, pes.Id as 'PesId'
	 FROM PersonLottery pl
	inner join Lottery lot on pl.LotteryId = lot.Id
	inner join Person pes on pl.PersonId = pes.Id
	WHERE lot.TypeLotteryId = (select top 1 Id from TypeLottery)
	and pl.Concurse = @concurseID
	--and pes.pes_id = 1
	group by pl.Id, pl.Concurse, pes.Id, pes.Name, pl.Game, pl.Hits, pl.Ticket_Amount

);

