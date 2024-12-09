using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarModelosExcursao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Preco = table.Column<float>(type: "INTEGER", nullable: false),
                    Staff_Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcursaoModel", x => x.Excursao_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcursaoModel");
        }
    }
}
