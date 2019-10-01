CREATE FUNCTION [dbo].[jogosConcurso] (@concurseID INT)  
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
		group by pl.Id, pl.Concurse, pes.Id, pes.Name, pl.Game, pl.Hits, pl.Ticket_Amount
	
);