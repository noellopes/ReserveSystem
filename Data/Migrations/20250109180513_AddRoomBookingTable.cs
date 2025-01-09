using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomBooking",
                columns: table => new
                {
                    ID_ROOM_BOOKING = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_BOOKING = table.Column<int>(type: "int", nullable: false),
                    ID_ROOM = table.Column<int>(type: "int", nullable: false),
                    PERSON_NUMBER = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomBooking", x => x.ID_ROOM_BOOKING);
                    table.ForeignKey(
                        name: "FK_RoomBooking_Booking_ID_BOOKING",
                        column: x => x.ID_BOOKING,
                        principalTable: "Booking",
                        principalColumn: "ID_BOOKING",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomBooking_Room_ID_ROOM",
                        column: x => x.ID_ROOM,
                        principalTable: "Room",
                        principalColumn: "ID_ROOM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_ID_BOOKING",
                table: "RoomBooking",
                column: "ID_BOOKING");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_ID_ROOM",
                table: "RoomBooking",
                column: "ID_ROOM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomBooking");
        }
    }
}
