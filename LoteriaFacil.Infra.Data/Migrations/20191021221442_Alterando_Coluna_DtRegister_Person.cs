using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoteriaFacil.Infra.Data.Migrations
{
    public partial class Alterando_Coluna_DtRegister_Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DtRegister",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DtRegister",
                table: "Person",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

        }
    }
}
