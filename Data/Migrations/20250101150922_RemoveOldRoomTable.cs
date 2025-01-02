using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOldRoomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Room");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    NumberOfRooms = table.Column<int>(nullable: false),
                    HasViews = table.Column<bool>(nullable: false),
                    AdaptedRooms = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomTypeId);
                });
        }
    }
}
