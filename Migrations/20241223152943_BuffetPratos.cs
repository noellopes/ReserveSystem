using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class BuffetPratos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuffetPrato",
                columns: table => new
                {
                    BuffetId = table.Column<int>(type: "int", nullable: false),
                    PratosPratoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuffetPrato", x => new { x.BuffetId, x.PratosPratoId });
                    table.ForeignKey(
                        name: "FK_BuffetPrato_Buffet_BuffetId",
                        column: x => x.BuffetId,
                        principalTable: "Buffet",
                        principalColumn: "BuffetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuffetPrato_Prato_PratosPratoId",
                        column: x => x.PratosPratoId,
                        principalTable: "Prato",
                        principalColumn: "PratoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuffetPrato_PratosPratoId",
                table: "BuffetPrato",
                column: "PratosPratoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuffetPrato");
        }
    }
}
