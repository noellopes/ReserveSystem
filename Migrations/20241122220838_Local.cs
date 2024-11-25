using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class Local : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            

            migrationBuilder.DropForeignKey(
                name: "FK_Salas_TipoSalas_IdTipoSala",
                table: "Salas");

            migrationBuilder.DropIndex(
                name: "IX_ReservaModel_ClienteId",
                table: "ReservaModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoSalas",
                table: "TipoSalas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salas",
                table: "Salas");

            migrationBuilder.AddColumn<int>(
                name: "ClienteModelClienteId",
                table: "ReservaModel",
                type: "int",
                nullable: true);

            
            migrationBuilder.AddForeignKey(
                name: "FK_ReservaModel_ClientModel_ClienteModelClienteId",
                table: "ReservaModel",
                column: "ClienteModelClienteId",
                principalTable: "ClientModel",
                principalColumn: "ClienteId");

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_ReservaModel_ClientModel_ClienteModelClienteId",
                table: "ReservaModel");*/

            migrationBuilder.DropForeignKey(
                name: "FK_Sala_TipoSala_IdTipoSala",
                table: "Sala");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_ReservaModel_ClienteModelClienteId",
                table: "ReservaModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoSala",
                table: "TipoSala");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sala",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "ClienteModelClienteId",
                table: "ReservaModel");

        }
    }
}
