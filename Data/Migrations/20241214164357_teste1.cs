using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class teste1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Job_Id",
                table: "StaffModel",
                newName: "jobID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_StaffModel_jobID_FK",
                table: "StaffModel",
                column: "jobID_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffModel_JobModel_jobID_FK",
                table: "StaffModel",
                column: "jobID_FK",
                principalTable: "JobModel",
                principalColumn: "jobID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffModel_JobModel_jobID_FK",
                table: "StaffModel");

            migrationBuilder.DropIndex(
                name: "IX_StaffModel_jobID_FK",
                table: "StaffModel");

            migrationBuilder.RenameColumn(
                name: "jobID_FK",
                table: "StaffModel",
                newName: "Job_Id");
        }
    }
}
