using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Reserva",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "FeedBackComment",
                table: "Reserva",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FeedbackTime",
                table: "Reserva",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeedbackValue",
                table: "Reserva",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpaceId",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "endTime",
                table: "Reserva",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "startTime",
                table: "Reserva",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_SpaceId",
                table: "Reserva",
                column: "SpaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Spaces_SpaceId",
                table: "Reserva",
                column: "SpaceId",
                principalTable: "Spaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Spaces_SpaceId",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_SpaceId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "FeedBackComment",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "FeedbackTime",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "FeedbackValue",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "SpaceId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "endTime",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "startTime",
                table: "Reserva");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Reserva",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
