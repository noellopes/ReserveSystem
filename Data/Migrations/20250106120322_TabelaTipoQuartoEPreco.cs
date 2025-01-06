using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class TabelaTipoQuartoEPreco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CancelationFee",
                table: "TQePreco");

            migrationBuilder.AddColumn<bool>(
                name: "InUse",
                table: "TQePreco",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InUse",
                table: "TQePreco");

            migrationBuilder.AddColumn<float>(
                name: "CancelationFee",
                table: "TQePreco",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
