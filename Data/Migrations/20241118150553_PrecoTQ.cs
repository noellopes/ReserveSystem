using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrecoTQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrecoTipoQuarto",
                columns: table => new
                {
                    TipoQuartoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capacidade = table.Column<int>(type: "int", nullable: false),
                    quantidadeQuartos = table.Column<int>(type: "int", nullable: false),
                    PrecoBase = table.Column<float>(type: "real", nullable: false),
                    taxaCancelamento = table.Column<float>(type: "real", nullable: false),
                    camaAdiconal = table.Column<float>(type: "real", nullable: false),
                    QuartoAdaptado = table.Column<bool>(type: "bit", nullable: false),
                    Vista = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecoTipoQuarto", x => x.TipoQuartoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrecoTipoQuarto");
        }
    }
}
