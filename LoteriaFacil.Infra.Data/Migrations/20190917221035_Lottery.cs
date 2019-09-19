using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoteriaFacil.Infra.Data.Migrations
{
    public partial class Lottery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Lottery_TypeLotteryId",
                table: "Lottery",
                column: "TypeLotteryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lottery");
        }
    }
}
