using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoteriaFacil.Infra.Data.Migrations
{
    public partial class Remocao_Tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PersonLottery");

            migrationBuilder.AlterColumn<decimal>(
                name: "Shared15",
                table: "Lottery",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Shared14",
                table: "Lottery",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Shared13",
                table: "Lottery",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Shared12",
                table: "Lottery",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Shared11",
                table: "Lottery",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10, 2)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Game",
                table: "Lottery",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtNextConcurse",
                table: "Lottery",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtConcurse",
                table: "Lottery",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Shared15",
                table: "Lottery",
                type: "decimal(10, 2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Shared14",
                table: "Lottery",
                type: "decimal(10, 2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Shared13",
                table: "Lottery",
                type: "decimal(10, 2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Shared12",
                table: "Lottery",
                type: "decimal(10, 2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Shared11",
                table: "Lottery",
                type: "decimal(10, 2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Game",
                table: "Lottery",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtNextConcurse",
                table: "Lottery",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DtConcurse",
                table: "Lottery",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateTable(
                name: "PersonLottery",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Concurse = table.Column<int>(type: "int", nullable: false),
                    Game = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Game_Checked = table.Column<DateTime>(type: "datetime", nullable: true),
                    Game_Register = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    Hits = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    LotteryId = table.Column<Guid>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true),
                    Ticket_Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLottery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonLottery_Lottery_LotteryId",
                        column: x => x.LotteryId,
                        principalTable: "Lottery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonLottery_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonLottery_LotteryId",
                table: "PersonLottery",
                column: "LotteryId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLottery_PersonId",
                table: "PersonLottery",
                column: "PersonId");
        }
    }
}
