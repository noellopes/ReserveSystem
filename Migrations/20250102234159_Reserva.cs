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
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEquipamento = table.Column<long>(type: "bigint", nullable: false),
                    EquipamentoIdEquipamento = table.Column<long>(type: "bigint", nullable: true),
                    IdTipoReserva = table.Column<long>(type: "bigint", nullable: false),
                    TipoReservaidTipoReserva = table.Column<long>(type: "bigint", nullable: true),
                    NumeroCliente = table.Column<long>(type: "bigint", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEstado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrecoTotal = table.Column<double>(type: "float", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalParticipantes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_ClientModel_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClientModel",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_Reserva_Equipamento_EquipamentoIdEquipamento",
                        column: x => x.EquipamentoIdEquipamento,
                        principalTable: "Equipamento",
                        principalColumn: "IdEquipamento");
                    table.ForeignKey(
                        name: "FK_Reserva_TipoReserva_TipoReservaidTipoReserva",
                        column: x => x.TipoReservaidTipoReserva,
                        principalTable: "TipoReserva",
                        principalColumn: "idTipoReserva");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_TipoEquipamentoIdTipoEquipamento",
                table: "Equipamento",
                column: "TipoEquipamentoIdTipoEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteId",
                table: "Reserva",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_EquipamentoIdEquipamento",
                table: "Reserva",
                column: "EquipamentoIdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_TipoReservaidTipoReserva",
                table: "Reserva",
                column: "TipoReservaidTipoReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_IdTipoSala",
                table: "Sala",
                column: "IdTipoSala");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "ClientModel");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "TipoReserva");

            migrationBuilder.DropTable(
                name: "TipoSala");

            migrationBuilder.DropTable(
                name: "TipoEquipamento");
        }
    }
}
