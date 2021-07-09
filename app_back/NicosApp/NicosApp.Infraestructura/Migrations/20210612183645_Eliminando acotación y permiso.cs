using Microsoft.EntityFrameworkCore.Migrations;

namespace NicosApp.Infraestructura.Migrations
{
    public partial class Eliminandoacotaciónypermiso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Acotacion",
                table: "FraccionArancelarias");

            migrationBuilder.DropColumn(
                name: "Permiso",
                table: "FraccionArancelarias");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Acotacion",
                table: "FraccionArancelarias",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Permiso",
                table: "FraccionArancelarias",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true);
        }
    }
}
