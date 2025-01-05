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
                name: "StaffModel",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staff_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffModel", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "ExcursaoModel",
                columns: table => new
                {
                    Excursao_Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Data_Inicio = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Data_Fim = table.Column<DateTime>(type: "DATE", nullable: false),
                    Preco = table.Column<double>(type: "FLOAT", nullable: false),
                    StaffId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcursaoModel", x => x.Excursao_Id);
                    table.ForeignKey(
                        name: "FK_ExcursaoModel_StaffModel_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffModel",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExcursaoModel_StaffId",
                table: "ExcursaoModel",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcursaoModel");

            migrationBuilder.DropTable(
                name: "StaffModel");
        }
    }
}
