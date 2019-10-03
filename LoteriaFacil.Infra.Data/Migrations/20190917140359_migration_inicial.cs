using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoteriaFacil.Infra.Data.Migrations
{
    public partial class migration_inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Password = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    DtRegister = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 11, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }
    }
}
