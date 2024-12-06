using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class StaffTestCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobTestModel",
                columns: table => new
                {
                    Job_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job_Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTestModel", x => x.Job_ID);
                });

            migrationBuilder.CreateTable(
                name: "StaffTestModel",
                columns: table => new
                {
                    Staff_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staff_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job_ID = table.Column<int>(type: "int", nullable: false),
                    JobTestJob_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffTestModel", x => x.Staff_Id);
                    table.ForeignKey(
                        name: "FK_StaffTestModel_JobTestModel_JobTestJob_ID",
                        column: x => x.JobTestJob_ID,
                        principalTable: "JobTestModel",
                        principalColumn: "Job_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffTestModel_JobTestJob_ID",
                table: "StaffTestModel",
                column: "JobTestJob_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffTestModel");

            migrationBuilder.DropTable(
                name: "JobTestModel");
        }
    }
}
