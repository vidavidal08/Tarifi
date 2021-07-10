using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NicosApp.Infraestructura.Migrations
{
    public partial class AgregandonuevaentidadpermisoFraccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermisosFraccion",
                columns: table => new
                {
                    IdPermisoFraccion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Permiso = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Acotacion = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    IdFraccionArancelaria = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosFraccion", x => x.IdPermisoFraccion);
                    table.ForeignKey(
                        name: "FK_FraccionArancelaria_PermisoFraccion",
                        column: x => x.IdFraccionArancelaria,
                        principalTable: "FraccionArancelarias",
                        principalColumn: "IdFraccionArancelaria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermisosFraccion_IdFraccionArancelaria",
                table: "PermisosFraccion",
                column: "IdFraccionArancelaria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermisosFraccion");
        }
    }
}
