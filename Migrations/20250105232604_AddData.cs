using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StaffModel",
                columns: new[] { "StaffId", "Job_Name", "Staff_Name" },
                values: new object[,]
                {
                    { 1, "Motorista", "João Silva" },
                    { 2, "Gestor de Excursão", "Maria Oliveira" },
                    { 3, "Guia Turistico", "Carlos Santos" },
                    { 4, "Motorista", "Ana Souza" },
                    { 5, "Gestor de Excursão", "Pedro Almeida" },
                    { 6, "Guia Turistico", "Luciana Costa" },
                    { 7, "Motorista", "Rafael Gomes" },
                    { 8, "Gestor de Excursão", "Fernanda Carvalho" },
                    { 9, "Guia Turistico", "Ricardo Pereira" },
                    { 10, "Motorista", "Juliana Mendes" },
                    { 11, "Gestor de Excursão", "Gustavo Rocha" },
                    { 12, "Guia Turistico", "Camila Ribeiro" },
                    { 13, "Motorista", "André Lima" },
                    { 14, "Gestor de Excursão", "Patrícia Fonseca" },
                    { 15, "Guia Turistico", "Tiago Martins" },
                    { 16, "Motorista", "Letícia Freitas" },
                    { 17, "Gestor de Excursão", "Bruno Vieira" },
                    { 18, "Guia Turistico", "Sara Fernandes" },
                    { 19, "Motorista", "Rodrigo Lopes" },
                    { 20, "Gestor de Excursão", "Natália Correia" },
                    { 21, "Guia Turistico", "Eduardo Cardoso" },
                    { 22, "Motorista", "Carolina Neves" },
                    { 23, "Gestor de Excursão", "Diego Farias" },
                    { 24, "Guia Turistico", "Vanessa Moreira" },
                    { 25, "Motorista", "Felipe Azevedo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "StaffModel",
                keyColumn: "StaffId",
                keyValue: 25);
        }
    }
}
