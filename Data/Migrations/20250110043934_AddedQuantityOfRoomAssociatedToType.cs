using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedQuantityOfRoomAssociatedToType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuantityOfRoomsAssociated",
                table: "RoomType",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityOfRoomsAssociated",
                table: "RoomType");
        }
    }
}
