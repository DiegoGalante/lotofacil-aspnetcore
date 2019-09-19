using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoteriaFacil.Infra.Data.Migrations
{
    public partial class PersonLottery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonLottery",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LotteryId = table.Column<Guid>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true),
                    Concurse = table.Column<int>(type: "int", nullable: false),
                    Game = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Hits = table.Column<int>(type: "int", nullable: false),
                    Ticket_Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValue: 0m),
                    Game_Checked = table.Column<DateTime>(type: "datetime", nullable: true),
                    Game_Register = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLottery");
        }
    }
}
