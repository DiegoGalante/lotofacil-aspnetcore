using LoteriaFacil.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LoteriaFacil.Infra.Data.Seed
{
    public static class SeedProcedureSP_CHECK_GAME
    {
        public static void Seed(LoteriaFacilContext loteriaFacilContext)
        {
            var procSP_CHECK_GAME = @"CREATE PROCEDURE [dbo].[SP_CHECK_GAME](
	                                    @lot_concurse INT,
	                                    --@tpj_id uniqueidentifier,
	                                    @pes_id uniqueidentifier = '00000000-0000-0000-0000-000000000000'
                                    ) --FIM PARAMETROS
                                    AS
                                    BEGIN
                                    SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	
	                                    print(CONCAT('PES_ID: ', @pes_id))

	                                    DECLARE @tpj_id uniqueidentifier;
	                                    SELECT TOP 1 @tpj_id = Id from TypeLottery WHERE Id = 'FFA60E23-F537-4AB1-9138-7FCF0AB24BB7' --loto fácil

                                    -- exec SP_CHECK_GAME 1642, 'C51FC003-0D7E-4009-ABB5-8E8F8615B0CF' 
                                    --'FFA60E23-F537-4AB1-9138-7FCF0AB24BB7'
                                    --, '00000000-0000-0000-0000-000000000000'

                                    -- select * from PersonLottery

                                    --INSERT INTO PersonLottery (Id, LotteryId, PersonId, Concurse, Game) VALUES ('68F1AE8E-E45A-451E-A2B5-1512BC9E17DD','471C4E2E-EC90-41B0-A0F1-CF45422AA97E', 'C51FC003-0D7E-4009-ABB5-8E8F8615B0CF', 1642, '01-02-03-05-08-09-10-11-14-15-16-19-23-24-25')
                                    --INSERT INTO PersonLottery (Id, LotteryId, PersonId, Concurse, Game) VALUES ('2129B82D-DB64-4F13-9038-D62A55D3F184','471C4E2E-EC90-41B0-A0F1-CF45422AA97E', 'C51FC003-0D7E-4009-ABB5-8E8F8615B0CF', 1642, '01-02-03-05-08-09-10-11-14-15-17-19-22-23-25')
                                    --INSERT INTO PersonLottery (Id, LotteryId, PersonId, Concurse, Game) VALUES ('E774B32A-02A4-4952-9F41-DBEBD495E862','471C4E2E-EC90-41B0-A0F1-CF45422AA97E', 'C51FC003-0D7E-4009-ABB5-8E8F8615B0CF', 1642, '01-02-03-05-06-08-09-10-12-15-19-21-22-23-25')


	                                    --UPDATE Person_Lottery
	                                    --		SET 
	                                    --			lot_id = null,
	                                    --			pl_hits = 0,
	                                    --			pl_game_checked = null
	                                    --		WHERE
	                                    --		pl_concurse = 1679

	                                    --delete from Lottery where lot_concurse = 1679
	

	                                    -- DECLARE @game varchar(100) = (SELECT TOP 1 lot_game from Lottery  where lot_concurse = @lot_concurse and tpj_id = @tpj_id order by 1 desc);
	                                    DECLARE @lot_game varchar(100);
	                                    DECLARE @lot_id uniqueidentifier;
	                                    DECLARE @lot_shared15 DECIMAL(10,2);
	                                    DECLARE @lot_shared14 DECIMAL(10,2);
	                                    DECLARE @lot_shared13 DECIMAL(10,2);
	                                    DECLARE @lot_shared12 DECIMAL(10,2);
	                                    DECLARE @lot_shared11 DECIMAL(10,2);
	
	                                    SELECT TOP 1 @lot_id = Id, 
	                                    @lot_game = Game, 
	                                    @lot_shared15 = Shared15, 
	                                    @lot_shared14 = Shared14, 
	                                    @lot_shared13 = Shared13, 
	                                    @lot_shared12 = Shared12, 
	                                    @lot_shared11 = Shared11
	                                    FROM Lottery 
	                                    where Concurse = @lot_concurse
	                                    and TypeLotteryId = @tpj_id

	                                    DECLARE @hit_pessoa INT = 0;

	                                    DECLARE @gamePessoas varchar(100)
	                                    DECLARE @pl_id uniqueidentifier
	                                    DECLARE @ticket_amount DECIMAL(10,2)

	                                    /*Descomentar a partir daqui*/
	                                    print('Declara o cursor: db_cursorPessoas');
	                                    IF @pes_id = '00000000-0000-0000-0000-000000000000'
	                                    BEGIN 
	                                    DECLARE db_cursorPessoas CURSOR FOR
	                                    SELECT  pl.Id, pl.Game
			                                    FROM PersonLottery pl
			                                    WHERE
			                                    pl.Concurse = @lot_concurse 
			                                    and
			                                    ISNULL(pl.Game_Checked, null) is null 
	                                    END
	                                    ELSE
	                                    BEGIN
	                                    DECLARE db_cursorPessoas CURSOR FOR
	                                    SELECT  pl.Id, pl.Game
			                                    FROM PersonLottery pl
			                                    WHERE
			                                    pl.Concurse = @lot_concurse 
			                                    and
			                                    pl.PersonId = @pes_id
			                                    and
			                                    ISNULL(pl.Game_Checked, null) is null 
	                                    END


	                                    print('Abre o cursor: db_cursorPessoas');
	                                    open db_cursorPessoas
	                                    FETCH NEXT FROM db_cursorPessoas INTO @pl_id, @gamePessoas
	
	                                    print('Inicia o cursor: db_cursorPessoas');
	                                    WHILE @@FETCH_STATUS = 0  
	                                    --INICIA O db_cursor
	                                    BEGIN
		                                    SET @hit_pessoa =0;

		                                    select value into #gameLoteria FROM string_split(@lot_game, '-')  WHERE 	RTRIM(LTRIM(value)) <> ''
		                                    ALTER TABLE #gameLoteria
		                                    ADD lot_game int NULL DEFAULT(NULL);

		                                    ALTER TABLE #gameLoteria
		                                    ADD pl_id uniqueidentifier NULL DEFAULT(null);

		                                    UPDATE #gameLoteria set lot_game = @lot_concurse;
		                                    UPDATE #gameLoteria set pl_id = @pl_id;

		                                    SELECT value into #gamePessoa FROM string_split(@gamePessoas, '-')  WHERE 	RTRIM(LTRIM(value)) <> ''
		                                    ALTER TABLE #gamePessoa
		                                    ADD lot_game int NULL DEFAULT(null);

		                                    ALTER TABLE #gamePessoa
		                                    ADD pl_id uniqueidentifier NULL DEFAULT(null);

		                                    UPDATE #gamePessoa set pl_id = @pl_id;
		                                    UPDATE #gamePessoa set lot_game = @lot_concurse;

		                                    --select * from #gameLoteria
		                                    --select * from #gamePessoa

		                                    SET @hit_pessoa = (select count(pes.value) as cont from #gamePessoa pes
		                                    INNER JOIN #gameLoteria lot on pes.lot_game = lot.lot_game
		                                    WHERE cast(pes.value as int) = cast(lot.value as int)
		                                    and pes.pl_id = lot.pl_id
		                                    and pes.lot_game = lot.lot_game)
		                                    --select count(pes.value) as cont from #gamePessoa pes
		                                    --INNER JOIN #gameLoteria lot on pes.lot_game = lot.lot_game
		                                    ----INNER JOIN Person_Lottery pl on pes.pes_id = pl.pes_id
		                                    --WHERE cast(pes.value as int) = cast(lot.value as int)
		                                    --and pes.pl_id = lot.pl_id

		                                    print(concat('HIT_PESSOA: ', @hit_pessoa));
						
		                                    drop table #gameLoteria
		                                    drop table #gamePessoa

		                                    IF @hit_pessoa = 15
		                                    BEGIN
			                                    SET @ticket_amount = @lot_shared15;
		                                    END
		                                    ELSE IF @hit_pessoa = 14
		                                    BEGIN
			                                    SET @ticket_amount = @lot_shared14;
		                                    END
		                                    ELSE IF @hit_pessoa = 13
		                                    BEGIN
			                                    SET @ticket_amount = @lot_shared13;
		                                    END
		                                    ELSE IF @hit_pessoa = 12
		                                    BEGIN
			                                    SET @ticket_amount = @lot_shared12;
		                                    END
		                                    ELSE IF @hit_pessoa = 11
		                                    BEGIN
			                                    SET @ticket_amount = @lot_shared11;
		                                    END
		                                    ELSE IF @hit_pessoa <= 10
		                                    BEGIN
			                                    SET @ticket_amount = 0;
		                                    END
				
		                                    print(CONCAT('PERSONLOTTERY_ID: ', @pl_id))
		                                    print(CONCAT('HITS_ID: ', @hit_pessoa))
		                                    print(CONCAT('LOT_ID: ', @lot_id))

		                                    UPDATE PersonLottery 
			                                    SET Hits = @hit_pessoa, LotteryId = @lot_id, Ticket_Amount = ISNULL(@ticket_amount, 0), Game_Checked = GETDATE()
		                                    WHERE Id = @pl_id and Concurse = @lot_concurse

	                                    print('Seta o próximo loop do cursor: db_cursorPessoas');
	                                    FETCH NEXT FROM db_cursorPessoas INTO  @pl_id, @gamePessoas
	                                    END 
	
	                                    print('Fecha o cursor: db_cursorPessoas');
	                                    CLOSE db_cursorPessoas  
	                                    print('Desaloca o cursor: db_cursorPessoas');
	                                    DEALLOCATE db_cursorPessoas 

	                                    IF @pes_id = '00000000-0000-0000-0000-000000000000'
	                                    BEGIN 
		                                    SELECT 
		                                    count(*)
		                                    --pl_id, lot_id, pes_id, pl_concurse, pl_game, pl_hits, pl_ticket_amount, pl_scheduled_game, pl_game_checked 
		                                    FROM PersonLottery
		                                    WHERE Concurse = @lot_concurse
		                                    and ISNULL(Game_Checked, null) is null
		                                    --ORDER BY pl_hits DESC
	                                    END
	                                    ELSE
	                                    BEGIN
		                                    SELECT 
		                                    count(*)
		                                    --pl_id, lot_id, pes_id, pl_concurse, pl_game, pl_hits, pl_ticket_amount, pl_scheduled_game, pl_game_checked 
		                                    FROM PersonLottery
		                                    WHERE Concurse = @lot_concurse
		                                    and ISNULL(Game_Checked, null) is null
		                                    and PersonId = @pes_id
		                                    --ORDER BY pl_hits DESC
	                                    END
	                                    /*Descomentar até o END acima*/
	
                                    --SQL Server Cursor Components
                                    --Based on the example above, cursors include these components:

                                    --DECLARE statements - Declare variables used in the code block
                                    --SET\SELECT statements - Initialize the variables to a specific value
                                    --DECLARE CURSOR statement - Populate the cursor with values that will be evaluated
                                    --NOTE - There are an equal number of variables in the DECLARE CURSOR FOR statement as there are in the SELECT statement.  This could be 1 or many variables and associated columns.
                                    --OPEN statement - Open the cursor to begin data processing
                                    --FETCH NEXT statements - Assign the specific values from the cursor to the variables
                                    --NOTE - This logic is used for the initial population before the WHILE statement and then again during each loop in the process as a portion of the WHILE statement
                                    --WHILE statement - Condition to begin and continue data processing
                                    --BEGIN...END statement - Start and end of the code block
                                    --NOTE - Based on the data processing multiple BEGIN...END statements can be used
                                    --Data processing - In this example, this logic is to backup a database to a specific path and file name, but this could be just about any DML or administrative logic
                                    --CLOSE statement - Releases the current data and associated locks, but permits the cursor to be re-opened
                                    --DEALLOCATE statement - Destroys the cursor

                                    END";

            loteriaFacilContext.Database.ExecuteSqlCommand(procSP_CHECK_GAME);
        }
    }
}
