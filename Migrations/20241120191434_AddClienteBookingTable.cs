using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddClienteBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Reserva");

            //migrationBuilder.DropTable(
            //    name: "Rooms");

            //migrationBuilder.DropTable(
            //    name: "Cliente");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIF = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    ID_BOOKING = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_CLIENT = table.Column<int>(type: "int", nullable: true),
                    CHECKIN_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CHECKOUT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BOOKING_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TOTAL_PERSONS_NUMBER = table.Column<int>(type: "int", nullable: false),
                    BOOKED = table.Column<bool>(type: "bit", nullable: false),
                    PAYMENT_STATUS = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.ID_BOOKING);
                    table.ForeignKey(
                        name: "FK_Booking_Client_ID_CLIENT",
                        column: x => x.ID_CLIENT,
                        principalTable: "Client",
                        principalColumn: "ClienteId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ID_CLIENT",
                table: "Booking",
                column: "ID_CLIENT");

            migrationBuilder.CreateIndex(
                name: "IX_Client_NIF",
                table: "Client",
                column: "NIF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Client");

            //migrationBuilder.CreateTable(
            //    name: "Cliente",
            //    columns: table => new
            //    {
            //        ClienteId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Login = table.Column<bool>(type: "bit", nullable: false),
            //        Nif = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cliente", x => x.ClienteId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Rooms",
            //    columns: table => new
            //    {
            //        RoomTypeId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AdaptedRoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Capacity = table.Column<int>(type: "int", nullable: false),
            //        HasView = table.Column<bool>(type: "bit", nullable: false),
            //        NumberOfRooms = table.Column<int>(type: "int", nullable: false),
            //        RoomType = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Rooms", x => x.RoomTypeId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Reserva",
            //    columns: table => new
            //    {
            //        ReservaId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ClienteId = table.Column<int>(type: "int", nullable: false),
            //        DataCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        DataCheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        DataReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EstadoPagamento = table.Column<bool>(type: "bit", nullable: false),
            //        NumeroPessoas = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Reserva", x => x.ReservaId);
            //        table.ForeignKey(
            //            name: "FK_Reserva_Cliente_ClienteId",
            //            column: x => x.ClienteId,
            //            principalTable: "Cliente",
            //            principalColumn: "ClienteId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reserva_ClienteId",
            //    table: "Reserva",
            //    column: "ClienteId");
        }
    }
}
