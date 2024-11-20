using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class dbRestaurante3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Prato_NomePratoIdPrato",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "NomePratoIdPrato",
                table: "Reserva",
                newName: "PratoIdPrato");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_NomePratoIdPrato",
                table: "Reserva",
                newName: "IX_Reserva_PratoIdPrato");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Prato_PratoIdPrato",
                table: "Reserva",
                column: "PratoIdPrato",
                principalTable: "Prato",
                principalColumn: "IdPrato");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Prato_PratoIdPrato",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "PratoIdPrato",
                table: "Reserva",
                newName: "NomePratoIdPrato");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_PratoIdPrato",
                table: "Reserva",
                newName: "IX_Reserva_NomePratoIdPrato");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Prato_NomePratoIdPrato",
                table: "Reserva",
                column: "NomePratoIdPrato",
                principalTable: "Prato",
                principalColumn: "IdPrato");
        }
    }
}
