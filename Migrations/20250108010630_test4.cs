using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class test4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ScheduleModel_TypeOfSheduleId",
                table: "ScheduleModel",
                column: "TypeOfSheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleModel_TypeOfSchedule_TypeOfSheduleId",
                table: "ScheduleModel",
                column: "TypeOfSheduleId",
                principalTable: "TypeOfSchedule",
                principalColumn: "TypeOfScheduleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleModel_TypeOfSchedule_TypeOfSheduleId",
                table: "ScheduleModel");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleModel_TypeOfSheduleId",
                table: "ScheduleModel");
        }
    }
}
