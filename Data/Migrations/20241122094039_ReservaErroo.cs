using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReservaErroo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Horario",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Maquinas",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "PersonalTrainer",
                table: "Reserva",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Reserva",
                newName: "Hour");

            migrationBuilder.AddColumn<int>(
                name: "PersonalTrainerId",
                table: "Reserva",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClientId",
                table: "Reserva",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_PersonalTrainerId",
                table: "Reserva",
                column: "PersonalTrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Client_ClientId",
                table: "Reserva",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_PersonalTrainer_PersonalTrainerId",
                table: "Reserva",
                column: "PersonalTrainerId",
                principalTable: "PersonalTrainer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Client_ClientId",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_PersonalTrainer_PersonalTrainerId",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_ClientId",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_PersonalTrainerId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "PersonalTrainerId",
                table: "Reserva");

            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "Reserva",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Reserva",
                newName: "PersonalTrainer");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Horario",
                table: "Reserva",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "Maquinas",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
