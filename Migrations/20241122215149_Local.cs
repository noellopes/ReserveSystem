using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class Local : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaModel_ClientModel_ClienteId",
                table: "ReservaModel");

            migrationBuilder.DropIndex(
                name: "IX_ReservaModel_ClienteId",
                table: "ReservaModel");

            migrationBuilder.AddColumn<int>(
                name: "ClienteModelClienteId",
                table: "ReservaModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoReserva = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Partcipantes = table.Column<int>(type: "int", nullable: false),
                    PrecoTotal = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ClienteModelClienteId = table.Column<int>(type: "int", nullable: true),
                    IdEquipamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_Reserva_ClientModel_ClienteModelClienteId",
                        column: x => x.ClienteModelClienteId,
                        principalTable: "ClientModel",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_Reserva_Equipamento_IdEquipamento",
                        column: x => x.IdEquipamento,
                        principalTable: "Equipamento",
                        principalColumn: "IdEquipamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaModel_ClienteModelClienteId",
                table: "ReservaModel",
                column: "ClienteModelClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteModelClienteId",
                table: "Reserva",
                column: "ClienteModelClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdEquipamento",
                table: "Reserva",
                column: "IdEquipamento");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaModel_ClientModel_ClienteModelClienteId",
                table: "ReservaModel",
                column: "ClienteModelClienteId",
                principalTable: "ClientModel",
                principalColumn: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaModel_ClientModel_ClienteModelClienteId",
                table: "ReservaModel");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_ReservaModel_ClienteModelClienteId",
                table: "ReservaModel");

            migrationBuilder.DropColumn(
                name: "ClienteModelClienteId",
                table: "ReservaModel");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaModel_ClienteId",
                table: "ReservaModel",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaModel_ClientModel_ClienteId",
                table: "ReservaModel",
                column: "ClienteId",
                principalTable: "ClientModel",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
