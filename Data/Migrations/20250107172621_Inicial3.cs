using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Prato_PratoIdPrato",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_PratoIdPrato",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "PratoIdPrato",
                table: "Reserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdPrato",
                table: "Reserva",
                column: "IdPrato");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Prato_IdPrato",
                table: "Reserva",
                column: "IdPrato",
                principalTable: "Prato",
                principalColumn: "IdPrato");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Prato_IdPrato",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IdPrato",
                table: "Reserva");

            migrationBuilder.AddColumn<int>(
                name: "PratoIdPrato",
                table: "Reserva",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_PratoIdPrato",
                table: "Reserva",
                column: "PratoIdPrato");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Prato_PratoIdPrato",
                table: "Reserva",
                column: "PratoIdPrato",
                principalTable: "Prato",
                principalColumn: "IdPrato");
        }
    }
}
