using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoomBookingRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_ID_BOOKING",
                table: "RoomBooking",
                column: "ID_BOOKING");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_ID_ROOM",
                table: "RoomBooking",
                column: "ID_ROOM");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBooking_Booking_ID_BOOKING",
                table: "RoomBooking",
                column: "ID_BOOKING",
                principalTable: "Booking",
                principalColumn: "ID_BOOKING",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBooking_Room_ID_ROOM",
                table: "RoomBooking",
                column: "ID_ROOM",
                principalTable: "Room",
                principalColumn: "ID_ROOM",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomBooking_Booking_ID_BOOKING",
                table: "RoomBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBooking_Room_ID_ROOM",
                table: "RoomBooking");

            migrationBuilder.DropIndex(
                name: "IX_RoomBooking_ID_BOOKING",
                table: "RoomBooking");

            migrationBuilder.DropIndex(
                name: "IX_RoomBooking_ID_ROOM",
                table: "RoomBooking");
        }
    }
}
