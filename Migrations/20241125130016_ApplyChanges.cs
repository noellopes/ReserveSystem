using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class ApplyChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientModel",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoradaCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientModel", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    IdEquipamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEquipamento = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    TipoEquipamento = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.IdEquipamento);
                });

            migrationBuilder.CreateTable(
                name: "TipoSala",
                columns: table => new
                {
                    IdTipoSala = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSala = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TamanhoSala = table.Column<int>(type: "int", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    PreçoHora = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSala", x => x.IdTipoSala);
                });

            migrationBuilder.CreateTable(
                name: "ReservaModel",
                columns: table => new
                {
                    ReservaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoReserva = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    DataReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Partcipantes = table.Column<int>(type: "int", nullable: false),
                    PrecoTotal = table.Column<double>(type: "float", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ClienteModelClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaModel", x => x.ReservaID);
                    table.ForeignKey(
                        name: "FK_ReservaModel_ClientModel_ClienteModelClienteId",
                        column: x => x.ClienteModelClienteId,
                        principalTable: "ClientModel",
                        principalColumn: "ClienteId");
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    IdSala = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TempoPreparação = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraFim = table.Column<TimeOnly>(type: "time", nullable: false),
                    IdTipoSala = table.Column<long>(type: "bigint", nullable: false)
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
                name: "IX_ReservaModel_ClienteModelClienteId",
                table: "ReservaModel",
                column: "ClienteModelClienteId");

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
                name: "ClientModel");

            migrationBuilder.DropTable(
                name: "TipoSala");
        }
    }
}
