using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class JobModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobModel_JobModel_JobModeljobID",
                table: "JobModel");

            migrationBuilder.DropIndex(
                name: "IX_JobModel_JobModeljobID",
                table: "JobModel");

            migrationBuilder.DropColumn(
                name: "JobModeljobID",
                table: "JobModel");

            migrationBuilder.AddColumn<string>(
                name: "jobName",
                table: "JobModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "jobName",
                table: "JobModel");

            migrationBuilder.AddColumn<int>(
                name: "JobModeljobID",
                table: "JobModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobModel_JobModeljobID",
                table: "JobModel",
                column: "JobModeljobID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobModel_JobModel_JobModeljobID",
                table: "JobModel",
                column: "JobModeljobID",
                principalTable: "JobModel",
                principalColumn: "jobID");
        }
    }
}
