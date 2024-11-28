using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class RenameNifToIdentification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NIF",
                table: "Client",
                newName: "Identification");

            migrationBuilder.RenameIndex(
                name: "IX_Client_NIF",
                table: "Client",
                newName: "IX_Client_Identification");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identification",
                table: "Client",
                newName: "NIF");

            migrationBuilder.RenameIndex(
                name: "IX_Client_Identification",
                table: "Client",
                newName: "IX_Client_NIF");
        }
    }
}
