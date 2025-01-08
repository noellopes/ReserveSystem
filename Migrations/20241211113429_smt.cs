using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class smt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 71,
                column: "ClienteId",
                value: 30);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ExcursaoFavoritaModel",
                keyColumn: "Id",
                keyValue: 71,
                column: "ClienteId",
                value: 20);
        }
    }
}
