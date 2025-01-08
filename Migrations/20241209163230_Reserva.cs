using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class Reserva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservaExcursaoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ExcursaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumPessoas = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaExcursaoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaExcursaoModel_ClienteTestModel_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteTestModel",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaExcursaoModel_ExcursaoModel_ExcursaoId",
                        column: x => x.ExcursaoId,
                        principalTable: "ExcursaoModel",
                        principalColumn: "Excursao_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaExcursaoModel_ClienteId",
                table: "ReservaExcursaoModel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaExcursaoModel_ExcursaoId",
                table: "ReservaExcursaoModel",
                column: "ExcursaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservaExcursaoModel");
        }
    }
}
