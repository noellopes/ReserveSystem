using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class JobModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobModel",
                columns: table => new
                {
                    jobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobModeljobID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobModel", x => x.jobID);
                    table.ForeignKey(
                        name: "FK_JobModel_JobModel_JobModeljobID",
                        column: x => x.JobModeljobID,
                        principalTable: "JobModel",
                        principalColumn: "jobID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobModel_JobModeljobID",
                table: "JobModel",
                column: "JobModeljobID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobModel");
        }
    }
}
