using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations.ReserveSystem
{
    /// <inheritdoc />
    public partial class UpdateRoomServicesBookingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReserved",
                table: "RoomServiceBooking");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "RoomServiceBooking");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "RoomServiceBooking",
                type: "start_date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "RoomServiceBooking",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "StaffConfirmation",
                table: "RoomServiceBooking",
                type: "staff_confirmation",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "RoomServiceId",
                table: "RoomServiceBooking",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "RoomServiceBooking",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "PaymentMade",
                table: "RoomServiceBooking",
                type: "payment_made",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "RoomServiceBooking",
                type: "end_date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "RoomServiceBooking",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientFeedback",
                table: "RoomServiceBooking",
                type: "client_feedback",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountToPay",
                table: "RoomServiceBooking",
                type: "amount_to_pay",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "RoomServiceBookingId",
                table: "RoomServiceBooking",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<bool>(
                name: "BookedState",
                table: "RoomServiceBooking",
                type: "booked_state",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "RoomServiceBooking",
                type: "date_time",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "RoomService",
                columns: table => new
                {
                    RoomServiceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomService", x => x.RoomServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StaffName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
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

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceBooking_Client_ClientId",
                table: "RoomServiceBooking",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceBooking_RoomService_RoomServiceId",
                table: "RoomServiceBooking",
                column: "RoomServiceId",
                principalTable: "RoomService",
                principalColumn: "RoomServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceBooking_Room_RoomId",
                table: "RoomServiceBooking",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomServiceBooking_Staff_StaffId",
                table: "RoomServiceBooking",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId",
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
                name: "Staff");

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

            migrationBuilder.DropColumn(
                name: "BookedState",
                table: "RoomServiceBooking");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "RoomServiceBooking");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "RoomServiceBooking",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "start_date");

            migrationBuilder.AlterColumn<int>(
                name: "StaffId",
                table: "RoomServiceBooking",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "StaffConfirmation",
                table: "RoomServiceBooking",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "staff_confirmation");

            migrationBuilder.AlterColumn<int>(
                name: "RoomServiceId",
                table: "RoomServiceBooking",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "RoomServiceBooking",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<bool>(
                name: "PaymentMade",
                table: "RoomServiceBooking",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "payment_made");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "RoomServiceBooking",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "end_date");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "RoomServiceBooking",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ClientFeedback",
                table: "RoomServiceBooking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "client_feedback",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AmountToPay",
                table: "RoomServiceBooking",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "amount_to_pay");

            migrationBuilder.AlterColumn<int>(
                name: "RoomServiceBookingId",
                table: "RoomServiceBooking",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true)
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReserved",
                table: "RoomServiceBooking",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "RoomServiceBooking",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
