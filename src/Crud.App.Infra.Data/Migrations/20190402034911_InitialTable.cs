using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Crud.App.Infra.Data.Migrations
{
    public partial class InitialTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeCompleto_PrimeiroNome = table.Column<string>(type: "varchar(50)", nullable: false),
                    NomeCompleto_SegundoNome = table.Column<string>(type: "varchar(50)", nullable: false),
                    NomeCompleto_UltimoNome = table.Column<string>(type: "varchar(50)", nullable: true),
                    Telefone_DDD = table.Column<string>(type: "varchar(02)", nullable: false),
                    Telefone_Numero = table.Column<string>(type: "varchar(09)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
