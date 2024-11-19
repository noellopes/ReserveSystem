using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class TabelaPrecoTipoQuarto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrecoTipoQuarto",
                columns: table => new
                {
                    id_RTPrice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasePrice = table.Column<float>(type: "real", nullable: false),
                    CancelationFee = table.Column<float>(type: "real", nullable: false),
                    AdicionalBeds = table.Column<float>(type: "real", nullable: false),
                    TipoQuartoId = table.Column<int>(type: "int", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrecoTipoQuarto");
        }
    }
}
