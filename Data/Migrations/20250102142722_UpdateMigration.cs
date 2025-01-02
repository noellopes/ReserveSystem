using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Client_ID_CLIENT",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "ID_CLIENT",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Client_ID_CLIENT",
                table: "Booking",
                column: "ID_CLIENT",
                principalTable: "Client",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Client_ID_CLIENT",
                table: "Booking");

            migrationBuilder.AlterColumn<int>(
                name: "ID_CLIENT",
                table: "Booking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Client_ID_CLIENT",
                table: "Booking",
                column: "ID_CLIENT",
                principalTable: "Client",
                principalColumn: "ClienteId");
        }
    }
}
