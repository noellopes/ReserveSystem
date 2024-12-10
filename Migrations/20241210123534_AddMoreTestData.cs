using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 20,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 12, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6862), new DateTime(2024, 12, 11, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6845) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 21,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 13, 16, 35, 33, 990, DateTimeKind.Utc).AddTicks(6866), new DateTime(2024, 12, 13, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6865) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 22,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 15, 18, 35, 33, 990, DateTimeKind.Utc).AddTicks(6868), new DateTime(2024, 12, 15, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6867) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 23,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 16, 15, 35, 33, 990, DateTimeKind.Utc).AddTicks(6870), new DateTime(2024, 12, 16, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6869) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 24,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 17, 17, 35, 33, 990, DateTimeKind.Utc).AddTicks(6872), new DateTime(2024, 12, 17, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6871) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 25,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 18, 15, 35, 33, 990, DateTimeKind.Utc).AddTicks(6874), new DateTime(2024, 12, 18, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6873) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 26,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 19, 18, 35, 33, 990, DateTimeKind.Utc).AddTicks(6876), new DateTime(2024, 12, 19, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6875) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 27,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 20, 20, 35, 33, 990, DateTimeKind.Utc).AddTicks(6877), new DateTime(2024, 12, 20, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6877) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 28,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 22, 0, 35, 33, 990, DateTimeKind.Utc).AddTicks(6879), new DateTime(2024, 12, 21, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6879) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 29,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 22, 22, 35, 33, 990, DateTimeKind.Utc).AddTicks(6881), new DateTime(2024, 12, 22, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6880) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 30,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 23, 21, 35, 33, 990, DateTimeKind.Utc).AddTicks(6883), new DateTime(2024, 12, 23, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6882) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 31,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 24, 17, 35, 33, 990, DateTimeKind.Utc).AddTicks(6885), new DateTime(2024, 12, 24, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6885) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 32,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 25, 16, 35, 33, 990, DateTimeKind.Utc).AddTicks(6887), new DateTime(2024, 12, 25, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6887) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 33,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 35, 33, 990, DateTimeKind.Utc).AddTicks(6889), new DateTime(2024, 12, 26, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6889) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 34,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 27, 18, 35, 33, 990, DateTimeKind.Utc).AddTicks(6891), new DateTime(2024, 12, 27, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 35,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 28, 16, 35, 33, 990, DateTimeKind.Utc).AddTicks(6892), new DateTime(2024, 12, 28, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6892) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 36,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 29, 17, 35, 33, 990, DateTimeKind.Utc).AddTicks(6894), new DateTime(2024, 12, 29, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6894) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 37,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 30, 19, 35, 33, 990, DateTimeKind.Utc).AddTicks(6896), new DateTime(2024, 12, 30, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6895) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 38,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 31, 21, 35, 33, 990, DateTimeKind.Utc).AddTicks(6898), new DateTime(2024, 12, 31, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6897) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 39,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2025, 1, 1, 20, 35, 33, 990, DateTimeKind.Utc).AddTicks(6899), new DateTime(2025, 1, 1, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(6899) });

            migrationBuilder.InsertData(
                table: "ReservaExcursaoModel",
                columns: new[] { "Id", "ClienteId", "DataReserva", "ExcursaoId", "NumPessoas", "ValorTotal" },
                values: new object[,]
                {
                    { 41, 22, new DateTime(2024, 12, 12, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7060), 23, 1, 50 },
                    { 42, 33, new DateTime(2024, 12, 13, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7062), 21, 4, 200 },
                    { 43, 24, new DateTime(2024, 12, 14, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7064), 25, 3, 150 },
                    { 44, 35, new DateTime(2024, 12, 15, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7065), 26, 5, 250 },
                    { 45, 36, new DateTime(2024, 12, 16, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7066), 34, 2, 120 },
                    { 46, 27, new DateTime(2024, 12, 17, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7067), 27, 1, 60 },
                    { 47, 28, new DateTime(2024, 12, 18, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7068), 38, 6, 300 },
                    { 48, 29, new DateTime(2024, 12, 19, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7069), 39, 3, 180 },
                    { 49, 31, new DateTime(2024, 12, 20, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7071), 32, 2, 110 },
                    { 50, 21, new DateTime(2024, 12, 21, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7072), 25, 4, 200 },
                    { 51, 32, new DateTime(2024, 12, 22, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7073), 21, 1, 50 },
                    { 52, 33, new DateTime(2024, 12, 23, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7074), 33, 5, 250 },
                    { 53, 34, new DateTime(2024, 12, 24, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7075), 26, 2, 120 },
                    { 54, 35, new DateTime(2024, 12, 25, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7076), 24, 3, 150 },
                    { 55, 23, new DateTime(2024, 12, 26, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7077), 37, 2, 100 },
                    { 56, 21, new DateTime(2024, 12, 27, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7078), 28, 4, 200 },
                    { 57, 28, new DateTime(2024, 12, 28, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7079), 29, 6, 300 },
                    { 58, 29, new DateTime(2024, 12, 29, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7080), 22, 2, 110 },
                    { 59, 40, new DateTime(2024, 12, 30, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7081), 33, 3, 150 },
                    { 60, 21, new DateTime(2024, 12, 11, 12, 35, 33, 990, DateTimeKind.Utc).AddTicks(7082), 22, 2, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 20,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 12, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4095), new DateTime(2024, 12, 11, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4080) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 21,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 13, 16, 34, 37, 749, DateTimeKind.Utc).AddTicks(4098), new DateTime(2024, 12, 13, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4098) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 22,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 15, 18, 34, 37, 749, DateTimeKind.Utc).AddTicks(4100), new DateTime(2024, 12, 15, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4100) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 23,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 16, 15, 34, 37, 749, DateTimeKind.Utc).AddTicks(4104), new DateTime(2024, 12, 16, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4103) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 24,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 17, 17, 34, 37, 749, DateTimeKind.Utc).AddTicks(4106), new DateTime(2024, 12, 17, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4105) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 25,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 18, 15, 34, 37, 749, DateTimeKind.Utc).AddTicks(4107), new DateTime(2024, 12, 18, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4107) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 26,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 19, 18, 34, 37, 749, DateTimeKind.Utc).AddTicks(4109), new DateTime(2024, 12, 19, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4109) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 27,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 20, 20, 34, 37, 749, DateTimeKind.Utc).AddTicks(4112), new DateTime(2024, 12, 20, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4112) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 28,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 22, 0, 34, 37, 749, DateTimeKind.Utc).AddTicks(4114), new DateTime(2024, 12, 21, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4114) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 29,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 22, 22, 34, 37, 749, DateTimeKind.Utc).AddTicks(4116), new DateTime(2024, 12, 22, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4116) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 30,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 23, 21, 34, 37, 749, DateTimeKind.Utc).AddTicks(4118), new DateTime(2024, 12, 23, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4117) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 31,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 24, 17, 34, 37, 749, DateTimeKind.Utc).AddTicks(4120), new DateTime(2024, 12, 24, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4119) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 32,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 25, 16, 34, 37, 749, DateTimeKind.Utc).AddTicks(4121), new DateTime(2024, 12, 25, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4121) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 33,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 34, 37, 749, DateTimeKind.Utc).AddTicks(4123), new DateTime(2024, 12, 26, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4123) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 34,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 27, 18, 34, 37, 749, DateTimeKind.Utc).AddTicks(4125), new DateTime(2024, 12, 27, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4124) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 35,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 28, 16, 34, 37, 749, DateTimeKind.Utc).AddTicks(4127), new DateTime(2024, 12, 28, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4126) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 36,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 29, 17, 34, 37, 749, DateTimeKind.Utc).AddTicks(4128), new DateTime(2024, 12, 29, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4128) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 37,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 30, 19, 34, 37, 749, DateTimeKind.Utc).AddTicks(4131), new DateTime(2024, 12, 30, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4131) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 38,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2024, 12, 31, 21, 34, 37, 749, DateTimeKind.Utc).AddTicks(4133), new DateTime(2024, 12, 31, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4133) });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 39,
                columns: new[] { "Data_Fim", "Data_Inicio" },
                values: new object[] { new DateTime(2025, 1, 1, 20, 34, 37, 749, DateTimeKind.Utc).AddTicks(4135), new DateTime(2025, 1, 1, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4134) });

            migrationBuilder.InsertData(
                table: "ReservaExcursaoModel",
                columns: new[] { "Id", "ClienteId", "DataReserva", "ExcursaoId", "NumPessoas", "ValorTotal" },
                values: new object[,]
                {
                    { 21, 22, new DateTime(2024, 12, 12, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4302), 23, 1, 50 },
                    { 22, 33, new DateTime(2024, 12, 13, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4304), 21, 4, 200 },
                    { 23, 24, new DateTime(2024, 12, 14, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4306), 25, 3, 150 },
                    { 24, 35, new DateTime(2024, 12, 15, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4307), 26, 5, 250 },
                    { 25, 36, new DateTime(2024, 12, 16, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4308), 34, 2, 120 },
                    { 26, 27, new DateTime(2024, 12, 17, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4309), 27, 1, 60 },
                    { 27, 28, new DateTime(2024, 12, 18, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4310), 38, 6, 300 },
                    { 28, 29, new DateTime(2024, 12, 19, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4311), 39, 3, 180 },
                    { 29, 31, new DateTime(2024, 12, 20, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4312), 32, 2, 110 },
                    { 30, 21, new DateTime(2024, 12, 21, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4314), 25, 4, 200 },
                    { 31, 32, new DateTime(2024, 12, 22, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4315), 21, 1, 50 },
                    { 32, 33, new DateTime(2024, 12, 23, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4316), 33, 5, 250 },
                    { 33, 34, new DateTime(2024, 12, 24, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4317), 26, 2, 120 },
                    { 34, 35, new DateTime(2024, 12, 25, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4318), 24, 3, 150 },
                    { 35, 23, new DateTime(2024, 12, 26, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4319), 37, 2, 100 },
                    { 36, 21, new DateTime(2024, 12, 27, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4320), 28, 4, 200 },
                    { 37, 28, new DateTime(2024, 12, 28, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4321), 29, 6, 300 },
                    { 38, 29, new DateTime(2024, 12, 29, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4322), 22, 2, 110 },
                    { 39, 40, new DateTime(2024, 12, 30, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4323), 33, 3, 150 },
                    { 40, 21, new DateTime(2024, 12, 11, 12, 34, 37, 749, DateTimeKind.Utc).AddTicks(4324), 22, 2, 100 }
                });
        }
    }
}
