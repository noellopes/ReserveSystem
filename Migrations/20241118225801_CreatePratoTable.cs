using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class CreatePratoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prato",
                columns: table => new
                {
                    pratoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prato", x => x.pratoID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prato");
        }
    }
}
