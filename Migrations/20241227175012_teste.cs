using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaysOffAndVacations",
                columns: table => new
                {
                    DayOffVacationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysOffAndVacations", x => x.DayOffVacationId);
                });

            migrationBuilder.CreateTable(
                name: "JobModel",
                columns: table => new
                {
                    jobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jobName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jobDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobModel", x => x.jobID);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    TypeOfSheduleId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartShiftTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndShiftTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Presence = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfSchedule",
                columns: table => new
                {
                    TypeOfScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfScheduleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfSchedule", x => x.TypeOfScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "StaffModel",
                columns: table => new
                {
                    Staff_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staff_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Staff_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Staff_Phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Staff_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jobID_FK = table.Column<int>(type: "int", nullable: false),
                    StartFunctionsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndFunctionsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysOffVacationCount = table.Column<int>(type: "int", nullable: false),
                    DrivingLicenseGrades = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverLicenseExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffModel", x => x.Staff_Id);
                    table.ForeignKey(
                        name: "FK_StaffModel_JobModel_jobID_FK",
                        column: x => x.jobID_FK,
                        principalTable: "JobModel",
                        principalColumn: "jobID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffModel_jobID_FK",
                table: "StaffModel",
                column: "jobID_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
