using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class bdRestaurante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Prato_NomePratoIdPrato",
                table: "Reserva");

            migrationBuilder.DropTable(
                name: "Prato");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_NomePratoIdPrato",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "NomePratoIdPrato",
                table: "Reserva");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NomePratoIdPrato",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Prato",
                columns: table => new
                {
                    IdPrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PratoNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prato", x => x.IdPrato);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_NomePratoIdPrato",
                table: "Reserva",
                column: "NomePratoIdPrato");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Prato_NomePratoIdPrato",
                table: "Reserva",
                column: "NomePratoIdPrato",
                principalTable: "Prato",
                principalColumn: "IdPrato",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
