using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class RoomServiceCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomService",
                columns: table => new
                {
                    ID_RoomService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_ID = table.Column<int>(type: "int", nullable: false),
                    Room_Service_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Room_Service_Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Room_Service_Price = table.Column<double>(type: "float", nullable: false),
                    Room_Service_Active = table.Column<bool>(type: "bit", nullable: false),
                    Room_Service_Limit_Hour = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomService", x => x.ID_RoomService);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomService");
        }
    }
}
