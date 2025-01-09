using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class addTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteTestModel",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteTestModel", x => x.ClienteId);
                });

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
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_Fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preco = table.Column<float>(type: "real", nullable: false),
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
                name: "ExcursaoFavoritaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ExcursaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcursaoFavoritaModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExcursaoFavoritaModel_ClienteTestModel_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteTestModel",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExcursaoFavoritaModel_ExcursaoModel_ExcursaoId",
                        column: x => x.ExcursaoId,
                        principalTable: "ExcursaoModel",
                        principalColumn: "ExcursaoId",
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

            migrationBuilder.CreateTable(
                name: "ReservaExcursaoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ExcursaoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataReserva = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    NumPessoas = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaExcursaoModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservaExcursaoModel_ClienteTestModel_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteTestModel",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaExcursaoModel_ExcursaoModel_ExcursaoId",
                        column: x => x.ExcursaoId,
                        principalTable: "ExcursaoModel",
                        principalColumn: "ExcursaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExcursaoFavoritaModel_ClienteId",
                table: "ExcursaoFavoritaModel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcursaoFavoritaModel_ExcursaoId",
                table: "ExcursaoFavoritaModel",
                column: "ExcursaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExcursaoModel_StaffId",
                table: "ExcursaoModel",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecarioModel_ExcursaoId",
                table: "PrecarioModel",
                column: "ExcursaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaExcursaoModel_ClienteId",
                table: "ReservaExcursaoModel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaExcursaoModel_ExcursaoId",
                table: "ReservaExcursaoModel",
                column: "ExcursaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcursaoFavoritaModel");

            migrationBuilder.DropTable(
                name: "PrecarioModel");

            migrationBuilder.DropTable(
                name: "ReservaExcursaoModel");

            migrationBuilder.DropTable(
                name: "ClienteTestModel");

            migrationBuilder.DropTable(
                name: "ExcursaoModel");

            migrationBuilder.DropTable(
                name: "StaffModel");
        }
    }
}
