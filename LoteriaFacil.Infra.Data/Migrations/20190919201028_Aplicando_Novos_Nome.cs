using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoteriaFacil.Infra.Data.Migrations
{
    public partial class Aplicando_Novos_Nome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeLottery",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", nullable: false),
                    Tens_Min = table.Column<int>(type: "int", nullable: false),
                    Bet_Min = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValue: 0m),
                    Hit_Min = table.Column<int>(type: "int", nullable: false),
                    Hit_Max = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLottery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lottery",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Concurse = table.Column<int>(type: "int", nullable: false),
                    DtConcurse = table.Column<DateTime>(type: "datetime", nullable: false),
                    Game = table.Column<string>(type: "varchar(200)", nullable: false),
                    Hit15 = table.Column<int>(type: "int", nullable: false),
                    Hit14 = table.Column<int>(type: "int", nullable: false),
                    Hit13 = table.Column<int>(type: "int", nullable: false),
                    Hit12 = table.Column<int>(type: "int", nullable: false),
                    Hit11 = table.Column<int>(type: "int", nullable: false),
                    Shared15 = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValue: 0m),
                    Shared14 = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValue: 0m),
                    Shared13 = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValue: 0m),
                    Shared12 = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValue: 0m),
                    Shared11 = table.Column<decimal>(type: "decimal(10, 2)", nullable: false, defaultValue: 0m),
                    DtNextConcurse = table.Column<DateTime>(type: "datetime", nullable: false),
                    TypeLotteryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lottery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lottery_TypeLottery_TypeLotteryId",
                        column: x => x.TypeLotteryId,
                        principalTable: "TypeLottery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonLottery",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LotteryId = table.Column<Guid>(nullable: true),
                    PersonId = table.Column<Guid>(nullable: true),
                    Concurse = table.Column<int>(type: "int", nullable: false),
                    Game = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Hits = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
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
                        name: "FK_PersonLottery_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lottery_TypeLotteryId",
                table: "Lottery",
                column: "TypeLotteryId");

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

            migrationBuilder.DropTable(
                name: "Lottery");

            migrationBuilder.DropTable(
                name: "TypeLottery");
        }
    }
}
