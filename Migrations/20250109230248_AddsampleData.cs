using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddsampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ReservaExcursaoModel",
                columns: new[] { "Id", "ClienteId", "DataReserva", "ExcursaoId", "NumPessoas", "ValorTotal" },
                values: new object[,]
                {
                    { 1, 21, new DateTime(2024, 12, 10, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5077), 1, 4, 200f },
                    { 2, 22, new DateTime(2024, 12, 15, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5147), 2, 2, 100f },
                    { 3, 23, new DateTime(2024, 12, 20, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5149), 3, 5, 250f },
                    { 4, 24, new DateTime(2024, 12, 22, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5151), 4, 3, 150f },
                    { 5, 25, new DateTime(2024, 12, 25, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5152), 5, 1, 50f },
                    { 6, 26, new DateTime(2024, 12, 26, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5154), 6, 2, 100f },
                    { 7, 27, new DateTime(2024, 12, 28, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5157), 7, 4, 200f },
                    { 8, 28, new DateTime(2024, 12, 30, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5159), 8, 3, 150f },
                    { 9, 29, new DateTime(2025, 1, 1, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5161), 9, 5, 250f },
                    { 10, 30, new DateTime(2025, 1, 3, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5190), 10, 2, 100f },
                    { 11, 31, new DateTime(2025, 1, 4, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5192), 11, 4, 200f },
                    { 12, 32, new DateTime(2025, 1, 5, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5194), 12, 3, 150f },
                    { 13, 33, new DateTime(2025, 1, 6, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5195), 13, 5, 250f },
                    { 14, 34, new DateTime(2025, 1, 7, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5197), 14, 2, 100f },
                    { 15, 35, new DateTime(2025, 1, 8, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5198), 15, 1, 50f },
                    { 16, 36, new DateTime(2025, 1, 9, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5200), 16, 3, 150f },
                    { 17, 37, new DateTime(2025, 1, 10, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5202), 17, 4, 200f },
                    { 18, 38, new DateTime(2025, 1, 11, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5203), 18, 2, 100f },
                    { 19, 39, new DateTime(2025, 1, 12, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5205), 19, 5, 250f },
                    { 20, 40, new DateTime(2025, 1, 13, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5207), 20, 4, 200f },
                    { 21, 21, new DateTime(2025, 1, 14, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5208), 21, 3, 150f },
                    { 22, 22, new DateTime(2025, 1, 15, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5210), 22, 2, 100f },
                    { 23, 23, new DateTime(2025, 1, 16, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5211), 23, 4, 200f },
                    { 24, 24, new DateTime(2025, 1, 17, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5214), 24, 5, 250f },
                    { 25, 25, new DateTime(2025, 1, 18, 23, 2, 48, 265, DateTimeKind.Local).AddTicks(5216), 25, 1, 50f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 25);
        }
    }
}
