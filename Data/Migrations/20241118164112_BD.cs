using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class BD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Mesa",
                newName: "Reservado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reservado",
                table: "Mesa",
                newName: "Estado");
        }
    }
}
