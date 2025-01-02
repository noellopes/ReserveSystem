using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class dbRestaurante7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Reserva",
                newName: "ClienteIdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_ClienteId",
                table: "Reserva",
                newName: "IX_Reserva_ClienteIdCliente");

            migrationBuilder.RenameColumn(
                name: "telemovel",
                table: "Cliente",
                newName: "Telemovel");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Cliente",
                newName: "IdCliente");

            migrationBuilder.AddColumn<string>(
                name: "NomeCliente",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteIdCliente",
                table: "Reserva",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteIdCliente",
                table: "Reserva");

            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.DropColumn(
                name: "NomeCliente",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "ClienteIdCliente",
                table: "Reserva",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_ClienteIdCliente",
                table: "Reserva",
                newName: "IX_Reserva_ClienteId");

            migrationBuilder.RenameColumn(
                name: "Telemovel",
                table: "Cliente",
                newName: "telemovel");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Cliente",
                newName: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId");
        }
    }
}
