using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class dbRestaurante2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPrato",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NomePratoIdPrato",
                table: "Reserva",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_NomePratoIdPrato",
                table: "Reserva",
                column: "NomePratoIdPrato");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Prato_NomePratoIdPrato",
                table: "Reserva",
                column: "NomePratoIdPrato",
                principalTable: "Prato",
                principalColumn: "IdPrato");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Prato_NomePratoIdPrato",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_NomePratoIdPrato",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "IdPrato",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "NomePratoIdPrato",
                table: "Reserva");
        }
    }
}
