using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBookingApi.Infrastructure.Migrations
{
    public partial class CreateRoutesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rutas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rutas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RutaId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Llegada = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viajes_Rutas_RutaId",
                        column: x => x.RutaId,
                        principalTable: "Rutas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asientos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ViajeId = table.Column<int>(type: "int", nullable: false),
                    Situacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Espacio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asientos", x => new { x.Id, x.ViajeId });
                    table.ForeignKey(
                        name: "FK_Asientos_Viajes_ViajeId",
                        column: x => x.ViajeId,
                        principalTable: "Viajes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asientos_ViajeId",
                table: "Asientos",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajes_RutaId",
                table: "Viajes",
                column: "RutaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asientos");

            migrationBuilder.DropTable(
                name: "Viajes");

            migrationBuilder.DropTable(
                name: "Rutas");
        }
    }
}
