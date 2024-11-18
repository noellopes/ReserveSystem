using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReservaModelV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "NumeroPessoas",
                table: "Reserva",
                newName: "TOTAL_PERSONS_NUMBER");

            migrationBuilder.RenameColumn(
                name: "EstadoPagamento",
                table: "Reserva",
                newName: "PAYMENT_STATUS");

            migrationBuilder.RenameColumn(
                name: "DataReserva",
                table: "Reserva",
                newName: "CHECKOUT_DATE");

            migrationBuilder.RenameColumn(
                name: "DataCheckOut",
                table: "Reserva",
                newName: "CHECKIN_DATE");

            migrationBuilder.RenameColumn(
                name: "DataCheckIn",
                table: "Reserva",
                newName: "BOOKING_DATE");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Reserva",
                newName: "ID_CLIENT");

            migrationBuilder.RenameColumn(
                name: "ReservaId",
                table: "Reserva",
                newName: "ID_BOOKING");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_ClienteId",
                table: "Reserva",
                newName: "IX_Reserva_ID_CLIENT");

            migrationBuilder.AddColumn<bool>(
                name: "BOOKED",
                table: "Reserva",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ID_CLIENT",
                table: "Reserva",
                column: "ID_CLIENT",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ID_CLIENT",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "BOOKED",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "TOTAL_PERSONS_NUMBER",
                table: "Reserva",
                newName: "NumeroPessoas");

            migrationBuilder.RenameColumn(
                name: "PAYMENT_STATUS",
                table: "Reserva",
                newName: "EstadoPagamento");

            migrationBuilder.RenameColumn(
                name: "ID_CLIENT",
                table: "Reserva",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "CHECKOUT_DATE",
                table: "Reserva",
                newName: "DataReserva");

            migrationBuilder.RenameColumn(
                name: "CHECKIN_DATE",
                table: "Reserva",
                newName: "DataCheckOut");

            migrationBuilder.RenameColumn(
                name: "BOOKING_DATE",
                table: "Reserva",
                newName: "DataCheckIn");

            migrationBuilder.RenameColumn(
                name: "ID_BOOKING",
                table: "Reserva",
                newName: "ReservaId");

            migrationBuilder.RenameIndex(
                name: "IX_Reserva_ID_CLIENT",
                table: "Reserva",
                newName: "IX_Reserva_ClienteId");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Reserva",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteId",
                table: "Reserva",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
