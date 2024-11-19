using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations.ReserveSystem
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Client_Name = table.Column<string>(type: "TEXT", nullable: false),
                    Client_Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Client_Address = table.Column<string>(type: "TEXT", nullable: false),
                    Client_Email = table.Column<string>(type: "TEXT", nullable: false),
                    Client_Tax_Id = table.Column<string>(type: "TEXT", nullable: false),
                    Client_Login = table.Column<bool>(type: "INTEGER", nullable: false),
                    Client_Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobName = table.Column<string>(type: "TEXT", nullable: false),
                    JobDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomID);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientID = table.Column<int>(type: "INTEGER", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookedState = table.Column<bool>(type: "INTEGER", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "INTEGER", nullable: false),
                    Payment = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Booking_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomService",
                columns: table => new
                {
                    RoomServiceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobID = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomServiceName = table.Column<string>(type: "TEXT", nullable: false),
                    RoomServiceDescription = table.Column<string>(type: "TEXT", nullable: false),
                    RoomServicePrice = table.Column<double>(type: "REAL", nullable: false),
                    RoomServiceActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    RoomServiceDuration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomService", x => x.RoomServiceID);
                    table.ForeignKey(
                        name: "FK_RoomService_Job_JobID",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobID = table.Column<int>(type: "INTEGER", nullable: false),
                    StaffName = table.Column<string>(type: "TEXT", nullable: false),
                    StaffEmail = table.Column<string>(type: "TEXT", nullable: false),
                    StaffPhone = table.Column<string>(type: "TEXT", nullable: false),
                    StaffPassword = table.Column<string>(type: "TEXT", nullable: false),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DismissalDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VacationDays = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                    table.ForeignKey(
                        name: "FK_Staff_Job_JobID",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomBooking",
                columns: table => new
                {
                    RoomBookingID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookingID = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomID = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomBooking", x => x.RoomBookingID);
                    table.ForeignKey(
                        name: "FK_RoomBooking_Booking_BookingID",
                        column: x => x.BookingID,
                        principalTable: "Booking",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomBooking_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomServiceBooking",
                columns: table => new
                {
                    RoomServicesBookingID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomServiceID = table.Column<int>(type: "INTEGER", nullable: false),
                    StaffID = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientID = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomID = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookedState = table.Column<bool>(type: "INTEGER", nullable: false),
                    StaffConfirmation = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClientFeedback = table.Column<int>(type: "INTEGER", nullable: true),
                    AmountToPay = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentMade = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomServiceBooking", x => x.RoomServicesBookingID);
                    table.ForeignKey(
                        name: "FK_RoomServiceBooking_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomServiceBooking_RoomService_RoomServiceID",
                        column: x => x.RoomServiceID,
                        principalTable: "RoomService",
                        principalColumn: "RoomServiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomServiceBooking_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomServiceBooking_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StaffID = table.Column<int>(type: "INTEGER", nullable: false),
                    TypeOfSchedule = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ShiftStartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ShiftEndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Available = table.Column<bool>(type: "INTEGER", nullable: false),
                    Present = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_Schedule_Staff_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staff",
                        principalColumn: "StaffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ClientID",
                table: "Booking",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_BookingID",
                table: "RoomBooking",
                column: "BookingID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBooking_RoomID",
                table: "RoomBooking",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomService_JobID",
                table: "RoomService",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceBooking_ClientID",
                table: "RoomServiceBooking",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceBooking_RoomID",
                table: "RoomServiceBooking",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceBooking_RoomServiceID",
                table: "RoomServiceBooking",
                column: "RoomServiceID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServiceBooking_StaffID",
                table: "RoomServiceBooking",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_StaffID",
                table: "Schedule",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_JobID",
                table: "Staff",
                column: "JobID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomBooking");

            migrationBuilder.DropTable(
                name: "RoomServiceBooking");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "RoomService");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Job");
        }
    }
}
