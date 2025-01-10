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
                name: "ClientModel",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCliente = table.Column<string>(type: "TEXT", nullable: false),
                    MoradaCliente = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    NIF = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientModel", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "TipoEquipamento",
                columns: table => new
                {
                    IdTipoEquipamento = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeTipoEquipamento = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEquipamento", x => x.IdTipoEquipamento);
                });

            migrationBuilder.CreateTable(
                name: "TipoReserva",
                columns: table => new
                {
                    idTipoReserva = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeReserva = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoReserva", x => x.idTipoReserva);
                });

            migrationBuilder.CreateTable(
                name: "TipoSala",
                columns: table => new
                {
                    IdTipoSala = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeSala = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TamanhoSala = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacidade = table.Column<int>(type: "INTEGER", nullable: false),
                    PreçoHora = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSala", x => x.IdTipoSala);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    IdEquipamento = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeEquipamento = table.Column<string>(type: "TEXT", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTipoEquipamento = table.Column<long>(type: "INTEGER", nullable: false),
                    TipoEquipamentoIdTipoEquipamento = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.IdEquipamento);
                    table.ForeignKey(
                        name: "FK_Equipamento_TipoEquipamento_TipoEquipamentoIdTipoEquipamento",
                        column: x => x.TipoEquipamentoIdTipoEquipamento,
                        principalTable: "TipoEquipamento",
                        principalColumn: "IdTipoEquipamento");
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
                    Floor = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomNumber = table.Column<int>(type: "INTEGER", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdEquipamento = table.Column<long>(type: "INTEGER", nullable: false),
                    EquipamentoIdEquipamento = table.Column<long>(type: "INTEGER", nullable: true),
                    IdTipoReserva = table.Column<long>(type: "INTEGER", nullable: false),
                    NumeroCliente = table.Column<long>(type: "INTEGER", nullable: false),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataReserva = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataEstado = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PrecoTotal = table.Column<double>(type: "REAL", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    TotalParticipantes = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_ClientModel_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClientModel",
                        principalColumn: "ClienteId");
                    table.ForeignKey(
                        name: "FK_Reserva_Equipamento_EquipamentoIdEquipamento",
                        column: x => x.EquipamentoIdEquipamento,
                        principalTable: "Equipamento",
                        principalColumn: "IdEquipamento");
                    table.ForeignKey(
                        name: "FK_Reserva_TipoReserva_IdTipoReserva",
                        column: x => x.IdTipoReserva,
                        principalTable: "TipoReserva",
                        principalColumn: "idTipoReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_TipoEquipamentoIdTipoEquipamento",
                table: "Equipamento",
                column: "TipoEquipamentoIdTipoEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteId",
                table: "Reserva",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_EquipamentoIdEquipamento",
                table: "Reserva",
                column: "EquipamentoIdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdTipoReserva",
                table: "Reserva",
                column: "IdTipoReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_IdTipoSala",
                table: "Sala",
                column: "IdTipoSala");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "ClientModel");

            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "TipoReserva");

            migrationBuilder.DropTable(
                name: "TipoSala");

            migrationBuilder.DropTable(
                name: "TipoEquipamento");
        }
    }
}
