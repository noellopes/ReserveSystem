using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomAndRoomTypeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Criar a tabela RoomType com a chave primária
            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasView = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomCapacity = table.Column<int>(type: "int", nullable: false),
                    AcessibilityRoom = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.RoomTypeId);
                });

            // Criar a tabela Room com a chave primária ID_ROOM e a chave estrangeira RoomTypeId
            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID_ROOM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID_ROOM);
                    table.ForeignKey(
                        name: "FK_Room_RoomType_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomType",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            // Criar o índice para a chave estrangeira RoomTypeId na tabela Room
            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover a chave estrangeira entre Room e RoomType
            migrationBuilder.DropForeignKey(
                name: "FK_Room_RoomType_RoomTypeId",
                table: "Room");

            // Remover a tabela Room
            migrationBuilder.DropTable(
                name: "Room");

            // Remover a tabela RoomType
            migrationBuilder.DropTable(
                name: "RoomType");
        }
    }
}

