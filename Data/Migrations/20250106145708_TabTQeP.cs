using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class TabTQeP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TQePreco",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    RoomQuantity = table.Column<int>(type: "int", nullable: false),
                    AcessibilityRoom = table.Column<bool>(type: "bit", nullable: false),
                    View = table.Column<bool>(type: "bit", nullable: false),
                    BasePrice = table.Column<float>(type: "real", nullable: false),
                    AdicionalBeds = table.Column<float>(type: "real", nullable: false),
                    InUse = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TQePreco", x => x.RoomTypeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TQePreco");
        }
    }
}
