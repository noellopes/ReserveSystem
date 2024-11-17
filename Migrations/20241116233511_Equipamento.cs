using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class Equipamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    IdEquipamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEquipamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEquipamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.IdEquipamento);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamento");
        }
    }
}
