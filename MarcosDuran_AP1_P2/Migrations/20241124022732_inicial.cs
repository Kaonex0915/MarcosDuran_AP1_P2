using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarcosDuran_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Costo = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ArticuloId);
                });

            migrationBuilder.CreateTable(
                name: "RegistroCombo",
                columns: table => new
                {
                    ComboId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Vendido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroCombo", x => x.ComboId);
                });

            migrationBuilder.CreateTable(
                name: "RegistroComboDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ComboId = table.Column<int>(type: "int", nullable: false),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroComboDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_RegistroComboDetalle_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "ArticuloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistroComboDetalle_RegistroCombo_ComboId",
                        column: x => x.ComboId,
                        principalTable: "RegistroCombo",
                        principalColumn: "ComboId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "ArticuloId", "Costo", "Descripcion", "Existencia", "Precio" },
                values: new object[,]
                {
                    { 1, 700, "Mouse", 15, 800 },
                    { 2, 7000, "Monitor", 6, 7500 },
                    { 3, 2000, "Teclado", 8, 2050 },
                    { 4, 35000, "Tarjeta grafica", 20, 38000 },
                    { 5, 1500, "Ram", 50, 1800 },
                    { 6, 3500, "CPU", 15, 3000 }
                });

            migrationBuilder.InsertData(
                table: "RegistroCombo",
                columns: new[] { "ComboId", "Descripcion", "Fecha", "Precio", "Vendido" },
                values: new object[,]
                {
                    { 1, "Monitor, mouse y teclado", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false },
                    { 2, "Computador Preensamblado", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false },
                    { 3, "Ram, CPU y tarjeta grafica", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false },
                    { 4, "Mouse y teclado", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroComboDetalle_ArticuloId",
                table: "RegistroComboDetalle",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroComboDetalle_ComboId",
                table: "RegistroComboDetalle",
                column: "ComboId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroComboDetalle");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "RegistroCombo");
        }
    }
}
