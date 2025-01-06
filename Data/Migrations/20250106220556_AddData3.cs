using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddData3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 25);

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "StaffId", "Job_Name", "Staff_Name", "TipoCarta" },
                values: new object[,]
                {
                    { 26, "Motorista", "João Silva", "C" },
                    { 27, "Guia Turístico", "Maria Ferreira", null },
                    { 28, "Motorista", "Carlos Mendes", "D" },
                    { 29, "Gestor de Excursão", "Ana Costa", null },
                    { 30, "Motorista", "Luís Pereira", "C+E" },
                    { 31, "Guia Turístico", "Rita Oliveira", null },
                    { 32, "Motorista", "Pedro Santos", "B" },
                    { 33, "Gestor de Excursão", "Marta Lopes", null },
                    { 34, "Motorista", "Fernando Gomes", "D+E" },
                    { 35, "Guia Turístico", "Cláudia Neves", null },
                    { 36, "Motorista", "António Silva", "C" },
                    { 37, "Gestor de Excursão", "Beatriz Sousa", null },
                    { 38, "Motorista", "Ricardo Teixeira", "D" },
                    { 39, "Guia Turístico", "Joana Martins", null },
                    { 40, "Motorista", "Tiago Rocha", "C+E" },
                    { 41, "Gestor de Excursão", "Helena Ribeiro", null },
                    { 42, "Motorista", "José Almeida", "B" },
                    { 43, "Guia Turístico", "Sofia Silva", null },
                    { 44, "Motorista", "Vítor Pinto", "C" },
                    { 45, "Gestor de Excursão", "Catarina Azevedo", null },
                    { 46, "Motorista", "André Matos", "D+E" },
                    { 47, "Guia Turístico", "Patrícia Lima", null },
                    { 48, "Motorista", "Eduardo Nunes", "B" },
                    { 49, "Gestor de Excursão", "Carla Moreira", null },
                    { 50, "Motorista", "Bruno Tavares", "C" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "StaffId",
                keyValue: 50);

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "StaffId", "Job_Name", "Staff_Name", "TipoCarta" },
                values: new object[,]
                {
                    { 1, "Motorista", "João Silva", "C" },
                    { 2, "Guia Turístico", "Maria Ferreira", null },
                    { 3, "Motorista", "Carlos Mendes", "D" },
                    { 4, "Gestor de Excursão", "Ana Costa", null },
                    { 5, "Motorista", "Luís Pereira", "C+E" },
                    { 6, "Guia Turístico", "Rita Oliveira", null },
                    { 7, "Motorista", "Pedro Santos", "B" },
                    { 8, "Gestor de Excursão", "Marta Lopes", null },
                    { 9, "Motorista", "Fernando Gomes", "D+E" },
                    { 10, "Guia Turístico", "Cláudia Neves", null },
                    { 11, "Motorista", "António Silva", "C" },
                    { 12, "Gestor de Excursão", "Beatriz Sousa", null },
                    { 13, "Motorista", "Ricardo Teixeira", "D" },
                    { 14, "Guia Turístico", "Joana Martins", null },
                    { 15, "Motorista", "Tiago Rocha", "C+E" },
                    { 16, "Gestor de Excursão", "Helena Ribeiro", null },
                    { 17, "Motorista", "José Almeida", "B" },
                    { 18, "Guia Turístico", "Sofia Silva", null },
                    { 19, "Motorista", "Vítor Pinto", "C" },
                    { 20, "Gestor de Excursão", "Catarina Azevedo", null },
                    { 21, "Motorista", "André Matos", "D+E" },
                    { 22, "Guia Turístico", "Patrícia Lima", null },
                    { 23, "Motorista", "Eduardo Nunes", "B" },
                    { 24, "Gestor de Excursão", "Carla Moreira", null },
                    { 25, "Motorista", "Bruno Tavares", "C" }
                });
        }
    }
}
