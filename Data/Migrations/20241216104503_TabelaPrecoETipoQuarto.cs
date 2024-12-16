using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class TabelaPrecoETipoQuarto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "TQePreco",
                columns: table => new
                {
                    id_RTPrice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    RoomQuantity = table.Column<int>(type: "int", nullable: false),
                    AcessibilityRoom = table.Column<bool>(type: "bit", nullable: false),
                    View = table.Column<bool>(type: "bit", nullable: false),
                    BasePrice = table.Column<float>(type: "real", nullable: false),
                    CancelationFee = table.Column<float>(type: "real", nullable: false),
                    AdicionalBeds = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TQePreco", x => x.id_RTPrice);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TQePreco");

            migrationBuilder.CreateTable(
                name: "TipoQuarto",
                columns: table => new
                {
                    TipoQuartoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcessibilityRoom = table.Column<bool>(type: "bit", nullable: false),
                    RoomQuantity = table.Column<int>(type: "int", nullable: false),
                    View = table.Column<bool>(type: "bit", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoQuarto", x => x.TipoQuartoId);
                });

            migrationBuilder.CreateTable(
                name: "PrecoTipoQuarto",
                columns: table => new
                {
                    id_RTPrice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoQuartoId = table.Column<int>(type: "int", nullable: false),
                    AdicionalBeds = table.Column<float>(type: "real", nullable: false),
                    BasePrice = table.Column<float>(type: "real", nullable: false),
                    CancelationFee = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecoTipoQuarto", x => x.id_RTPrice);
                    table.ForeignKey(
                        name: "FK_PrecoTipoQuarto_TipoQuarto_TipoQuartoId",
                        column: x => x.TipoQuartoId,
                        principalTable: "TipoQuarto",
                        principalColumn: "TipoQuartoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrecoTipoQuarto_TipoQuartoId",
                table: "PrecoTipoQuarto",
                column: "TipoQuartoId");
        }
    }
}
