using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
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
                    ExcursaoId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    table.PrimaryKey("PK_ExcursaoModel", x => x.ExcursaoId);
                    table.ForeignKey(
                        name: "FK_ExcursaoModel_StaffModel_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffModel",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrecarioModel",
                columns: table => new
                {
                    PrecoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<float>(type: "real", nullable: false),
                    Data_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExcursaoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecarioModel", x => x.PrecoId);
                    table.ForeignKey(
                        name: "FK_PrecarioModel_ExcursaoModel_ExcursaoId",
                        column: x => x.ExcursaoId,
                        principalTable: "ExcursaoModel",
                        principalColumn: "ExcursaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExcursaoModel_StaffId",
                table: "ExcursaoModel",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecarioModel_ExcursaoId",
                table: "PrecarioModel",
                column: "ExcursaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrecarioModel");

            migrationBuilder.DropTable(
                name: "ExcursaoModel");

            migrationBuilder.DropTable(
                name: "StaffModel");
        }
    }
}
