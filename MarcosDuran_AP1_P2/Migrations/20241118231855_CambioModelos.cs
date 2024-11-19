using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarcosDuran_AP1_P2.Migrations
{
    /// <inheritdoc />
    public partial class CambioModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Vendido",
                table: "RegistroCombo",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "RegistroCombo",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Precio",
                table: "Articulos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Costo",
                table: "Articulos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
                columns: new[] { "ComboId", "Descripcion", "Fecha", "Precio", "RegistroComboDetalleDetalleId", "Vendido" },
                values: new object[,]
                {
                    { 1, "Monitor, mouse y teclado", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false },
                    { 2, "Computador Preensamblado", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false },
                    { 3, "Ram, CPU y tarjeta grafica", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false },
                    { 4, "Mouse y teclado", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articulos",
                keyColumn: "ArticuloId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articulos",
                keyColumn: "ArticuloId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articulos",
                keyColumn: "ArticuloId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Articulos",
                keyColumn: "ArticuloId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articulos",
                keyColumn: "ArticuloId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Articulos",
                keyColumn: "ArticuloId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RegistroCombo",
                keyColumn: "ComboId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RegistroCombo",
                keyColumn: "ComboId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RegistroCombo",
                keyColumn: "ComboId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RegistroCombo",
                keyColumn: "ComboId",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Vendido",
                table: "RegistroCombo",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Fecha",
                table: "RegistroCombo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "Articulos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Costo",
                table: "Articulos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
