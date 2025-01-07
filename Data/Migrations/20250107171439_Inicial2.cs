using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteIdCliente",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_ClienteIdCliente",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Reserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdCliente",
                table: "Reserva",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_IdCliente",
                table: "Reserva",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_IdCliente",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IdCliente",
                table: "Reserva");

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Reserva",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteIdCliente",
                table: "Reserva",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteIdCliente",
                table: "Reserva",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente");
        }
    }
}
