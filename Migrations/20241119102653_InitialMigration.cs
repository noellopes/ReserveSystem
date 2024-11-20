using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        /// 

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_ReservaModel_Cliente_ID_CLIENT", // The name of the foreign key
               table: "ReservaModel");

            migrationBuilder.DropTable(
                name: "ReservaModel");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<bool>(type: "bit", nullable: false),
                    Nif = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "ReservaModel",
                columns: table => new
                {
                    ID_BOOKING = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CHECKIN_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CHECKOUT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BOOKING_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BOOKED = table.Column<bool>(type: "bit", nullable: false),
                    PAYMENT_STATUS = table.Column<bool>(type: "bit", nullable: false),
                    TOTAL_PERSONS_NUMBER = table.Column<int>(type: "int", nullable: false),
                    ID_CLIENT = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaModel", x => x.ID_BOOKING);
                    table.ForeignKey(
                        name: "FK_ReservaModel_Cliente_ID_CLIENT",
                        column: x => x.ID_CLIENT,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaModel_ID_CLIENT",
                table: "ReservaModel",
                column: "ID_CLIENT");
        }

        /// <inheritdoc />
        
    }
}
