using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "ScheduleModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleModel",
                table: "ScheduleModel",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleModel_StaffId",
                table: "ScheduleModel",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleModel_StaffModel_StaffId",
                table: "ScheduleModel",
                column: "StaffId",
                principalTable: "StaffModel",
                principalColumn: "Staff_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleModel_StaffModel_StaffId",
                table: "ScheduleModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleModel",
                table: "ScheduleModel");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleModel_StaffId",
                table: "ScheduleModel");

            migrationBuilder.RenameTable(
                name: "ScheduleModel",
                newName: "Schedule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "ScheduleId");
        }
    }
}
