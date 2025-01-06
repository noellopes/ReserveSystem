using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDataMotoristaTransporte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MotoristaTransporte",
                columns: new[] { "MotoristaTransporteId", "StaffId", "TransporteId" },
                values: new object[,]
                {
                    { 26, 26, 26 },
                    { 27, 27, 27 },
                    { 28, 28, 28 },
                    { 29, 29, 29 },
                    { 30, 30, 30 },
                    { 31, 31, 31 },
                    { 32, 32, 32 },
                    { 33, 33, 33 },
                    { 34, 34, 34 },
                    { 35, 35, 35 },
                    { 36, 36, 36 },
                    { 37, 37, 37 },
                    { 38, 38, 38 },
                    { 39, 39, 39 },
                    { 40, 40, 40 },
                    { 41, 41, 41 },
                    { 42, 42, 42 },
                    { 43, 43, 43 },
                    { 44, 44, 44 },
                    { 45, 45, 45 },
                    { 46, 46, 46 },
                    { 47, 47, 47 },
                    { 48, 48, 48 },
                    { 49, 49, 49 },
                    { 50, 50, 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "MotoristaTransporte",
                keyColumn: "MotoristaTransporteId",
                keyValue: 50);
        }
    }
}
