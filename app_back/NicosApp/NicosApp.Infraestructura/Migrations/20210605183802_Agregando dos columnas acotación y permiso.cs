using Microsoft.EntityFrameworkCore.Migrations;

namespace NicosApp.Infraestructura.Migrations
{
    public partial class Agregandodoscolumnasacotaciónypermiso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Acotacion",
                table: "FraccionArancelarias",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Permiso",
                table: "FraccionArancelarias",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acotacion",
                table: "FraccionArancelarias");

            migrationBuilder.DropColumn(
                name: "Permiso",
                table: "FraccionArancelarias");
        }
    }
}
