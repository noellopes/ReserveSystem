using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class createTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Job_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Job_Decription = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Job_ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomService",
                columns: table => new
                {
                    ID_Room_Service = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Job_ID = table.Column<int>(type: "int", nullable: false),
                    Room_Service_Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Room_Service_Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Room_Service_Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomService", x => x.ID_Room_Service);
                    table.ForeignKey(
                        name: "FK_RoomService_Job_Job_ID",
                        column: x => x.Job_ID,
                        principalTable: "Job",
                        principalColumn: "Job_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomServicePrice",
                columns: table => new
                {
                    ID_Room_Service_Price = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Room_Service = table.Column<int>(type: "int", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Room_Service_Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomServicePrice", x => x.ID_Room_Service_Price);
                    table.ForeignKey(
                        name: "FK_RoomServicePrice_RoomService_ID_Room_Service",
                        column: x => x.ID_Room_Service,
                        principalTable: "RoomService",
                        principalColumn: "ID_Room_Service",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomService_Job_ID",
                table: "RoomService",
                column: "Job_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomServicePrice_ID_Room_Service",
                table: "RoomServicePrice",
                column: "ID_Room_Service");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomServicePrice");

            migrationBuilder.DropTable(
                name: "RoomService");

            migrationBuilder.DropTable(
                name: "Job");
        }
    }
}
