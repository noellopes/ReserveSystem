using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class ExcursaoFavoritaCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ValorTotal",
                table: "ReservaExcursaoModel",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "ExcursaoModel",
                type: "DECIMAL(18,0)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "FLOAT");

            migrationBuilder.CreateTable(
                name: "ExcursaoFavoritaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ExcursaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcursaoFavoritaModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExcursaoFavoritaModel_ClienteTestModel_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteTestModel",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExcursaoFavoritaModel_ExcursaoModel_ExcursaoId",
                        column: x => x.ExcursaoId,
                        principalTable: "ExcursaoModel",
                        principalColumn: "Excursao_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 20,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 13, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2601), new DateTime(2024, 12, 12, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2584), 50.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 21,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 14, 13, 43, 11, 363, DateTimeKind.Utc).AddTicks(2607), new DateTime(2024, 12, 14, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2606), 80.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 22,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 16, 15, 43, 11, 363, DateTimeKind.Utc).AddTicks(2609), new DateTime(2024, 12, 16, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2608), 120.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 23,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 17, 12, 43, 11, 363, DateTimeKind.Utc).AddTicks(2611), new DateTime(2024, 12, 17, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2610), 40.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 24,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 18, 14, 43, 11, 363, DateTimeKind.Utc).AddTicks(2612), new DateTime(2024, 12, 18, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2612), 150.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 25,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 19, 12, 43, 11, 363, DateTimeKind.Utc).AddTicks(2614), new DateTime(2024, 12, 19, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2614), 200.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 26,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 20, 15, 43, 11, 363, DateTimeKind.Utc).AddTicks(2616), new DateTime(2024, 12, 20, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2616), 120.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 27,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 21, 17, 43, 11, 363, DateTimeKind.Utc).AddTicks(2620), new DateTime(2024, 12, 21, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2618), 250.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 28,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 22, 21, 43, 11, 363, DateTimeKind.Utc).AddTicks(2622), new DateTime(2024, 12, 22, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2621), 500.00m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 29,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 23, 19, 43, 11, 363, DateTimeKind.Utc).AddTicks(2624), new DateTime(2024, 12, 23, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2623), 350.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 30,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 24, 18, 43, 11, 363, DateTimeKind.Utc).AddTicks(2626), new DateTime(2024, 12, 24, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2625), 180.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 31,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 25, 14, 43, 11, 363, DateTimeKind.Utc).AddTicks(2628), new DateTime(2024, 12, 25, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2627), 90.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 32,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 26, 13, 43, 11, 363, DateTimeKind.Utc).AddTicks(2630), new DateTime(2024, 12, 26, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2629), 130.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 33,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 27, 14, 43, 11, 363, DateTimeKind.Utc).AddTicks(2632), new DateTime(2024, 12, 27, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2631), 60.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 34,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 28, 15, 43, 11, 363, DateTimeKind.Utc).AddTicks(2633), new DateTime(2024, 12, 28, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2633), 80.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 35,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 29, 13, 43, 11, 363, DateTimeKind.Utc).AddTicks(2637), new DateTime(2024, 12, 29, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2635), 70.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 36,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 30, 14, 43, 11, 363, DateTimeKind.Utc).AddTicks(2639), new DateTime(2024, 12, 30, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2638), 110.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 37,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 31, 16, 43, 11, 363, DateTimeKind.Utc).AddTicks(2641), new DateTime(2024, 12, 31, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2640), 150.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 38,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2025, 1, 1, 18, 43, 11, 363, DateTimeKind.Utc).AddTicks(2642), new DateTime(2025, 1, 1, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2642), 180.0m });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 39,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2025, 1, 2, 17, 43, 11, 363, DateTimeKind.Utc).AddTicks(2644), new DateTime(2025, 1, 2, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2644), 220.0m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 13, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2846), 50m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 14, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2852), 200m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 15, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2853), 150m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 16, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2854), 250m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 17, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2855), 120m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 18, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2856), 60m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 19, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2858), 300m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 20, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2859), 180m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 21, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2860), 110m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 22, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2861), 200m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 23, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2862), 50m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 24, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2863), 250m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 25, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2865), 120m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 26, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2866), 150m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 27, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2867), 100m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 28, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2868), 200m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 29, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2869), 300m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 30, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2870), 110m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 31, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2871), 150m });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 12, 9, 43, 11, 363, DateTimeKind.Utc).AddTicks(2872), 100m });

            migrationBuilder.CreateIndex(
                name: "IX_ExcursaoFavoritaModel_ClienteId",
                table: "ExcursaoFavoritaModel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcursaoFavoritaModel_ExcursaoId",
                table: "ExcursaoFavoritaModel",
                column: "ExcursaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcursaoFavoritaModel");

            migrationBuilder.AlterColumn<int>(
                name: "ValorTotal",
                table: "ReservaExcursaoModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "ExcursaoModel",
                type: "FLOAT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,0)");

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 20,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 12, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8488), new DateTime(2024, 12, 11, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8472), 50.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 21,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 13, 19, 37, 51, 338, DateTimeKind.Utc).AddTicks(8490), new DateTime(2024, 12, 13, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8489), 80.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 22,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 15, 21, 37, 51, 338, DateTimeKind.Utc).AddTicks(8492), new DateTime(2024, 12, 15, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8492), 120.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 23,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 16, 18, 37, 51, 338, DateTimeKind.Utc).AddTicks(8494), new DateTime(2024, 12, 16, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8494), 40.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 24,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 17, 20, 37, 51, 338, DateTimeKind.Utc).AddTicks(8496), new DateTime(2024, 12, 17, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8496), 150.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 25,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 18, 18, 37, 51, 338, DateTimeKind.Utc).AddTicks(8498), new DateTime(2024, 12, 18, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8498), 200.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 26,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 19, 21, 37, 51, 338, DateTimeKind.Utc).AddTicks(8500), new DateTime(2024, 12, 19, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8499), 120.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 27,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 20, 23, 37, 51, 338, DateTimeKind.Utc).AddTicks(8503), new DateTime(2024, 12, 20, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8503), 250.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 28,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 22, 3, 37, 51, 338, DateTimeKind.Utc).AddTicks(8505), new DateTime(2024, 12, 21, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8504), 500.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 29,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 23, 1, 37, 51, 338, DateTimeKind.Utc).AddTicks(8507), new DateTime(2024, 12, 22, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8506), 350.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 30,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 24, 0, 37, 51, 338, DateTimeKind.Utc).AddTicks(8508), new DateTime(2024, 12, 23, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8508), 180.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 31,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 24, 20, 37, 51, 338, DateTimeKind.Utc).AddTicks(8510), new DateTime(2024, 12, 24, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8510), 90.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 32,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 25, 19, 37, 51, 338, DateTimeKind.Utc).AddTicks(8512), new DateTime(2024, 12, 25, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8511), 130.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 33,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 26, 20, 37, 51, 338, DateTimeKind.Utc).AddTicks(8514), new DateTime(2024, 12, 26, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8513), 60.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 34,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 27, 21, 37, 51, 338, DateTimeKind.Utc).AddTicks(8515), new DateTime(2024, 12, 27, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8515), 80.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 35,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 28, 19, 37, 51, 338, DateTimeKind.Utc).AddTicks(8517), new DateTime(2024, 12, 28, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8517), 70.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 36,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 29, 20, 37, 51, 338, DateTimeKind.Utc).AddTicks(8519), new DateTime(2024, 12, 29, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8518), 110.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 37,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2024, 12, 30, 22, 37, 51, 338, DateTimeKind.Utc).AddTicks(8522), new DateTime(2024, 12, 30, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8522), 150.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 38,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2025, 1, 1, 0, 37, 51, 338, DateTimeKind.Utc).AddTicks(8524), new DateTime(2024, 12, 31, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8523), 180.0 });

            migrationBuilder.UpdateData(
                table: "ExcursaoModel",
                keyColumn: "Excursao_Id",
                keyValue: 39,
                columns: new[] { "Data_Fim", "Data_Inicio", "Preco" },
                values: new object[] { new DateTime(2025, 1, 1, 23, 37, 51, 338, DateTimeKind.Utc).AddTicks(8526), new DateTime(2025, 1, 1, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8525), 220.0 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 12, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8692), 50 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 13, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8693), 200 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 14, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8694), 150 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 15, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8695), 250 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 16, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8696), 120 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 17, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8697), 60 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 18, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8698), 300 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 19, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8699), 180 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 20, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8700), 110 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 21, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8701), 200 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 22, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8703), 50 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8704), 250 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 24, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8705), 120 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 25, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8706), 150 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 26, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8707), 100 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 27, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8708), 200 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 28, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8709), 300 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 29, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8710), 110 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 30, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8711), 150 });

            migrationBuilder.UpdateData(
                table: "ReservaExcursaoModel",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "DataReserva", "ValorTotal" },
                values: new object[] { new DateTime(2024, 12, 11, 15, 37, 51, 338, DateTimeKind.Utc).AddTicks(8712), 100 });
        }
    }
}
