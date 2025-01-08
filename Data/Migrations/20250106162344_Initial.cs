using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identification = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdentificationType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClienteId);
                });

            //migrationBuilder.CreateTable(
            //    name: "Cliente",
            //    columns: table => new
            //    {
            //        IdCliente = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CC = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
            //        Telemovel = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cliente", x => x.IdCliente);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Employee",
            //    columns: table => new
            //    {
            //        EmployeeId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
            //        Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        WorkSchedule = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Employee", x => x.EmployeeId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Mesa",
            //    columns: table => new
            //    {
            //        IdMesa = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NumeroLugares = table.Column<int>(type: "int", nullable: false),
            //        Reservado = table.Column<bool>(type: "bit", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Mesa", x => x.IdMesa);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Prato",
            //    columns: table => new
            //    {
            //        IdPrato = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PratoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Preco = table.Column<int>(type: "int", nullable: false),
            //        Dia = table.Column<int>(type: "int", nullable: false),
            //        Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Prato", x => x.IdPrato);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RoomType",
            //    columns: table => new
            //    {
            //        RoomTypeId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        HasView = table.Column<bool>(type: "bit", nullable: false),
            //        Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        RoomCapacity = table.Column<int>(type: "int", nullable: false),
            //        AcessibilityRoom = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoomType", x => x.RoomTypeId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Booking",
            //    columns: table => new
            //    {
            //        ID_BOOKING = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ID_CLIENT = table.Column<int>(type: "int", nullable: false),
            //        CHECKIN_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CHECKOUT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        BOOKING_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        TOTAL_PERSONS_NUMBER = table.Column<int>(type: "int", nullable: false),
            //        BOOKED = table.Column<bool>(type: "bit", nullable: false),
            //        PAYMENT_STATUS = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Booking", x => x.ID_BOOKING);
            //        table.ForeignKey(
            //            name: "FK_Booking_Client_ID_CLIENT",
            //            column: x => x.ID_CLIENT,
            //            principalTable: "Client",
            //            principalColumn: "ClienteId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Reserva",
            //    columns: table => new
            //    {
            //        IdReserva = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        IdCliente = table.Column<int>(type: "int", nullable: false),
            //        ClienteIdCliente = table.Column<int>(type: "int", nullable: false),
            //        IdMesa = table.Column<int>(type: "int", nullable: true),
            //        NumeroPessoas = table.Column<int>(type: "int", nullable: false),
            //        DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Observacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //        IdPrato = table.Column<int>(type: "int", nullable: true),
            //        PratoIdPrato = table.Column<int>(type: "int", nullable: true),
            //        Aprovacao = table.Column<bool>(type: "bit", nullable: false),
            //        NumeroMesa = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Reserva", x => x.IdReserva);
            //        table.ForeignKey(
            //            name: "FK_Reserva_Cliente_ClienteIdCliente",
            //            column: x => x.ClienteIdCliente,
            //            principalTable: "Cliente",
            //            principalColumn: "IdCliente",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Reserva_Prato_PratoIdPrato",
            //            column: x => x.PratoIdPrato,
            //            principalTable: "Prato",
            //            principalColumn: "IdPrato");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Room",
            //    columns: table => new
            //    {
            //        ID_ROOM = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoomTypeId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Room", x => x.ID_ROOM);
            //        table.ForeignKey(
            //            name: "FK_Room_RoomType_RoomTypeId",
            //            column: x => x.RoomTypeId,
            //            principalTable: "RoomType",
            //            principalColumn: "RoomTypeId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Booking_ID_CLIENT",
            //    table: "Booking",
            //    column: "ID_CLIENT");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Client_Identification",
            //    table: "Client",
            //    column: "Identification",
            //    unique: true);

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Reserva_ClienteIdCliente",
            //        table: "Reserva",
            //        column: "ClienteIdCliente");

            //    migrationBuilder.CreateIndex(
            //        name: "IX_Reserva_PratoIdPrato",
            //        table: "Reserva",
            //        column: "PratoIdPrato");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Room_RoomTypeId",
            //    table: "Room",
            //    column: "RoomTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Mesa");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Prato");

            migrationBuilder.DropTable(
                name: "RoomType");
        }
    }
}
