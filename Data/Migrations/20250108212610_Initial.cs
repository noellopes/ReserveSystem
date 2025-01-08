using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuantityStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "Room_Type",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasView = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    RoomCapacity = table.Column<int>(type: "int", nullable: false),
                    AcessibilityRoom = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Type", x => x.RoomTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfSchedule",
                columns: table => new
                {
                    TypeOfScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfScheduleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TypeOfScheduleDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfSchedule", x => x.TypeOfScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StaffEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffDriversLicense = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StaffDriversLicenseExpiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartFunctionsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndFunctionsDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaysOfVacationCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_Staff_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item_Room",
                columns: table => new
                {
                    ItemRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    itemsItemId = table.Column<int>(type: "int", nullable: true),
                    RoomQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item_Room", x => x.ItemRoomId);
                    table.ForeignKey(
                        name: "FK_Item_Room_Items_itemsItemId",
                        column: x => x.itemsItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_Item_Room_Room_Type_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "Room_Type",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Room_Room_Type_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "Room_Type",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    SchedulesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartShiftTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndShiftTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    isPrecense = table.Column<bool>(type: "bit", nullable: false),
                    isAvailable = table.Column<bool>(type: "bit", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    TypeOfScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.SchedulesId);
                    table.ForeignKey(
                        name: "FK_Schedules_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_TypeOfSchedule_TypeOfScheduleId",
                        column: x => x.TypeOfScheduleId,
                        principalTable: "TypeOfSchedule",
                        principalColumn: "TypeOfScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consumptions",
                columns: table => new
                {
                    ConsumptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    itemsItemId = table.Column<int>(type: "int", nullable: true),
                    QuantityConsumed = table.Column<int>(type: "int", nullable: false),
                    ConsumedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumptions", x => x.ConsumptionId);
                    table.ForeignKey(
                        name: "FK_Consumptions_Items_itemsItemId",
                        column: x => x.itemsItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_Consumptions_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Checkin_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Checkout_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Booking_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Booked = table.Column<bool>(type: "bit", nullable: false),
                    Total_Persons_Number = table.Column<int>(type: "int", nullable: false),
                    Payment_Status = table.Column<bool>(type: "bit", nullable: false),
                    Room_BookingRoomBookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Client_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client_Adress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Client_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client_Nif = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Client_Login = table.Column<bool>(type: "bit", nullable: false),
                    Client_Status = table.Column<bool>(type: "bit", nullable: false),
                    WantsCleaning = table.Column<bool>(type: "bit", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "BookingId");
                });

            migrationBuilder.CreateTable(
                name: "Room_Booking",
                columns: table => new
                {
                    RoomBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Persons_Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Booking", x => x.RoomBookingId);
                    table.ForeignKey(
                        name: "FK_Room_Booking_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Room_Booking_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cleaning_Schedule",
                columns: table => new
                {
                    CleaningScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomBookingId = table.Column<int>(type: "int", nullable: false),
                    room_BookingRoomBookingId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    DateServices = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CleaningDone = table.Column<bool>(type: "bit", nullable: false),
                    CleaningDesired = table.Column<bool>(type: "bit", nullable: false),
                    PreferredCleaningStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PreferredCleaningEndTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cleaning_Schedule", x => x.CleaningScheduleId);
                    table.ForeignKey(
                        name: "FK_Cleaning_Schedule_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cleaning_Schedule_Room_Booking_room_BookingRoomBookingId",
                        column: x => x.room_BookingRoomBookingId,
                        principalTable: "Room_Booking",
                        principalColumn: "RoomBookingId");
                    table.ForeignKey(
                        name: "FK_Cleaning_Schedule_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Room_BookingRoomBookingId",
                table: "Booking",
                column: "Room_BookingRoomBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Cleaning_Schedule_ClientId",
                table: "Cleaning_Schedule",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Cleaning_Schedule_room_BookingRoomBookingId",
                table: "Cleaning_Schedule",
                column: "room_BookingRoomBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Cleaning_Schedule_StaffId",
                table: "Cleaning_Schedule",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_BookingId",
                table: "Client",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumptions_itemsItemId",
                table: "Consumptions",
                column: "itemsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumptions_RoomId",
                table: "Consumptions",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Room_itemsItemId",
                table: "Item_Room",
                column: "itemsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Room_RoomTypeId",
                table: "Item_Room",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeId",
                table: "Room",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Booking_BookingId",
                table: "Room_Booking",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Booking_RoomId",
                table: "Room_Booking",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_StaffId",
                table: "Schedules",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_TypeOfScheduleId",
                table: "Schedules",
                column: "TypeOfScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_JobId",
                table: "Staff",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Room_Booking_Room_BookingRoomBookingId",
                table: "Booking",
                column: "Room_BookingRoomBookingId",
                principalTable: "Room_Booking",
                principalColumn: "RoomBookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Room_Booking_Room_BookingRoomBookingId",
                table: "Booking");

            migrationBuilder.DropTable(
                name: "Cleaning_Schedule");

            migrationBuilder.DropTable(
                name: "Consumptions");

            migrationBuilder.DropTable(
                name: "Item_Room");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "TypeOfSchedule");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Room_Booking");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Room_Type");
        }
    }
}
