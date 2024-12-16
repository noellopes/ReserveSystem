using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class PTBug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "Spaces",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Spaces",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "capacity",
                table: "Spaces",
                newName: "Capacity");

            migrationBuilder.RenameColumn(
                name: "startTime",
                table: "Reserva",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "endTime",
                table: "Reserva",
                newName: "EndTime");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PersonalTrainer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "PersonalTrainer");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Spaces",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Spaces",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Spaces",
                newName: "capacity");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Reserva",
                newName: "startTime");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Reserva",
                newName: "endTime");
        }
    }
}
