using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddAllErDiagramTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ClientFeedback",
                table: "RoomServiceBooking",
                type: "INTEGER(1)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER(1)");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Address = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Nif = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(type: "VARCHAR(5)", maxLength: 5, nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ServiceActive = table.Column<bool>(type: "bit", nullable: false),
                    ServiceLimitHours = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomService_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobId = table.Column<int>(type: "INTEGER", nullable: false),
                    ScheduleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Password = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
                    ContractStartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ContractExpiryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VacationDays = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StaffId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateOnly>(type: "DATE", nullable: false),
                    ShiftStart = table.Column<TimeSpan>(type: "TIME", nullable: false),
                    ShiftEnd = table.Column<TimeSpan>(type: "TIME", nullable: false),
                    Available = table.Column<bool>(type: "BIT", nullable: false),
                    Present = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceBooking_ClientId",
                table: "RoomServiceBooking",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceBooking_RoomId",
                table: "RoomServiceBooking",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceBooking_RoomServiceId",
                table: "RoomServiceBooking",
                column: "RoomServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceBooking_StaffId",
                table: "RoomServiceBooking",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomService_JobId",
                table: "RoomService",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_StaffId",
                table: "Schedule",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_JobId",
                table: "Staff",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceBooking_Client_ClientId",
                table: "RoomServiceBooking",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceBooking_RoomService_RoomServiceId",
                table: "RoomServiceBooking",
                column: "RoomServiceId",
                principalTable: "RoomService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceBooking_Room_RoomId",
                table: "RoomServiceBooking",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceBooking_Staff_StaffId",
                table: "RoomServiceBooking",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomServiceBooking_Client_ClientId",
                table: "RoomServiceBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomServiceBooking_RoomService_RoomServiceId",
                table: "RoomServiceBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomServiceBooking_Room_RoomId",
                table: "RoomServiceBooking");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomServiceBooking_Staff_StaffId",
                table: "RoomServiceBooking");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "RoomService");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropIndex(
                name: "IX_RoomServiceBooking_ClientId",
                table: "RoomServiceBooking");

            migrationBuilder.DropIndex(
                name: "IX_RoomServiceBooking_RoomId",
                table: "RoomServiceBooking");

            migrationBuilder.DropIndex(
                name: "IX_RoomServiceBooking_RoomServiceId",
                table: "RoomServiceBooking");

            migrationBuilder.DropIndex(
                name: "IX_RoomServiceBooking_StaffId",
                table: "RoomServiceBooking");

            migrationBuilder.AlterColumn<int>(
                name: "ClientFeedback",
                table: "RoomServiceBooking",
                type: "INTEGER(1)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER(1)",
                oldNullable: true);
        }
    }
}
