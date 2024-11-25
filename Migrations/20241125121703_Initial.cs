using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteModel",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCliente = table.Column<string>(type: "TEXT", maxLength: 8000, nullable: false),
                    MoradaCliente = table.Column<string>(type: "TEXT", maxLength: 8000, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 8000, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 8000, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 8000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteModel", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    IdEquipamento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeEquipamento = table.Column<string>(type: "TEXT", maxLength: 8000, nullable: false),
                    TipoEquipamento = table.Column<string>(type: "TEXT", maxLength: 8000, nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.IdEquipamento);
                });

            migrationBuilder.CreateTable(
                name: "TipoSala",
                columns: table => new
                {
                    IdTipoSala = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeSala = table.Column<string>(type: "TEXT", maxLength: 8000, nullable: false),
                    TamanhoSala = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacidade = table.Column<int>(type: "INTEGER", nullable: false),
                    PreçoHora = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSala", x => x.IdTipoSala);
                });

            migrationBuilder.CreateTable(
                name: "ReservaModel",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoReserva = table.Column<string>(type: "TEXT", maxLength: 8000, nullable: false),
                    DataReserva = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Partcipantes = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecoTotal = table.Column<double>(type: "REAL", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaModel", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_ReservaModel_ClienteModel_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClienteModel",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    IdSala = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TempoPreparação = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HoraInicio = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    HoraFim = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    IdTipoSala = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.IdSala);
                    table.ForeignKey(
                        name: "FK_Sala_TipoSala_IdTipoSala",
                        column: x => x.IdTipoSala,
                        principalTable: "TipoSala",
                        principalColumn: "IdTipoSala",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaModel_ClienteId",
                table: "ReservaModel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_IdTipoSala",
                table: "Sala",
                column: "IdTipoSala");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "ReservaModel");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "ClienteModel");

            migrationBuilder.DropTable(
                name: "TipoSala");
        }
    }
}
