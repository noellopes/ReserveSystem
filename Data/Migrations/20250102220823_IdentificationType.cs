using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class IdentificationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Client_NIF",
                table: "Client");

            migrationBuilder.AlterColumn<string>(
                name: "NIF",
                table: "Client",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentificationType",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Client_NIF",
                table: "Client",
                column: "NIF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Client_NIF",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "IdentificationType",
                table: "Client");

            migrationBuilder.AlterColumn<string>(
                name: "NIF",
                table: "Client",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Client_NIF",
                table: "Client",
                column: "NIF",
                unique: true,
                filter: "[NIF] IS NOT NULL");
        }
    }
}
