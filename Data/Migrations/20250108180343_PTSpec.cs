using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PTSpec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "PersonalTrainer");

            migrationBuilder.AddColumn<string>(
                name: "Specialties",
                table: "PersonalTrainer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialties",
                table: "PersonalTrainer");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PersonalTrainer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
