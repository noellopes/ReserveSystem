using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingBookingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Client_ID_CLIENT",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_ID_CLIENT",
                table: "Booking");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ClienteId",
                table: "Booking",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Client_ClienteId",
                table: "Booking",
                column: "ClienteId",
                principalTable: "Client",
                principalColumn: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Client_ClienteId",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_ClienteId",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Booking");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ID_CLIENT",
                table: "Booking",
                column: "ID_CLIENT");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Client_ID_CLIENT",
                table: "Booking",
                column: "ID_CLIENT",
                principalTable: "Client",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
