using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoteriaFacil.Infra.Data.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lottery");

            migrationBuilder.DropTable(
                name: "Type_Lottery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Type_Lottery",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Bet_Min = table.Column<decimal>(nullable: false),
                    Hit_Max = table.Column<int>(nullable: false),
                    Hit_Min = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Tens_Min = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Lottery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lottery",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Concurse = table.Column<int>(nullable: false),
                    DtConcurse = table.Column<DateTime>(nullable: false),
                    DtNextConcurse = table.Column<DateTime>(nullable: false),
                    Game = table.Column<string>(nullable: true),
                    Hit11 = table.Column<int>(nullable: false),
                    Hit12 = table.Column<int>(nullable: false),
                    Hit13 = table.Column<int>(nullable: false),
                    Hit14 = table.Column<int>(nullable: false),
                    Hit15 = table.Column<int>(nullable: false),
                    Shared11 = table.Column<decimal>(nullable: false),
                    Shared12 = table.Column<decimal>(nullable: false),
                    Shared13 = table.Column<decimal>(nullable: false),
                    Shared14 = table.Column<decimal>(nullable: false),
                    Shared15 = table.Column<decimal>(nullable: false),
                    Type_LotteryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lottery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lottery_Type_Lottery_Type_LotteryId",
                        column: x => x.Type_LotteryId,
                        principalTable: "Type_Lottery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lottery_Type_LotteryId",
                table: "Lottery",
                column: "Type_LotteryId");
        }
    }
}
