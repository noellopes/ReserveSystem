using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrecoTipoQ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrecoTipoQuarto",
                table: "PrecoTipoQuarto");

            migrationBuilder.AlterColumn<int>(
                name: "TipoQuartoId",
                table: "PrecoTipoQuarto",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "id_RTPrice",
                table: "PrecoTipoQuarto",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrecoTipoQuarto",
                table: "PrecoTipoQuarto",
                column: "id_RTPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrecoTipoQuarto",
                table: "PrecoTipoQuarto");

            migrationBuilder.DropColumn(
                name: "id_RTPrice",
                table: "PrecoTipoQuarto");

            migrationBuilder.AlterColumn<int>(
                name: "TipoQuartoId",
                table: "PrecoTipoQuarto",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrecoTipoQuarto",
                table: "PrecoTipoQuarto",
                column: "TipoQuartoId");
        }
    }
}
