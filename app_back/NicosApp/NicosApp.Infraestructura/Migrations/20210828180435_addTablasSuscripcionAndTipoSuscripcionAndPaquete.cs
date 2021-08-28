using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NicosApp.Infraestructura.Migrations
{
    public partial class addTablasSuscripcionAndTipoSuscripcionAndPaquete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paquetes",
                columns: table => new
                {
                    IdPaquete = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquetes", x => x.IdPaquete);
                });

            migrationBuilder.CreateTable(
                name: "TipoSuscripcion",
                columns: table => new
                {
                    IdTipoSuscripcion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DiasVigencia = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Reelegible = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Precio = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSuscripcion", x => x.IdTipoSuscripcion);
                });

            migrationBuilder.CreateTable(
                name: "Suscripciones",
                columns: table => new
                {
                    IdSuscripcion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: false),
                    EsVigente = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IdTipoSuscripcion = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdApplicationUser = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdPaquete = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suscripciones", x => x.IdSuscripcion);
                    table.ForeignKey(
                        name: "FK_Suscripcion_Paquete",
                        column: x => x.IdPaquete,
                        principalTable: "Paquetes",
                        principalColumn: "IdPaquete",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suscripcion_TipoSuscripcion",
                        column: x => x.IdTipoSuscripcion,
                        principalTable: "TipoSuscripcion",
                        principalColumn: "IdTipoSuscripcion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Suscripcion_User",
                        column: x => x.IdApplicationUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_IdApplicationUser",
                table: "Suscripciones",
                column: "IdApplicationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_IdPaquete",
                table: "Suscripciones",
                column: "IdPaquete");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_IdTipoSuscripcion",
                table: "Suscripciones",
                column: "IdTipoSuscripcion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suscripciones");

            migrationBuilder.DropTable(
                name: "Paquetes");

            migrationBuilder.DropTable(
                name: "TipoSuscripcion");
        }
    }
}
