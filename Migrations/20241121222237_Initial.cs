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
                name: "Ingrediente",
                columns: table => new
                {
                    IngredienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UnidadeMedida = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    QuantidadeDisponivel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.IngredienteId);
                });

            migrationBuilder.CreateTable(
                name: "Quarto",
                columns: table => new
                {
                    QuartoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quarto", x => x.QuartoId);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    QuartoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_Quarto_QuartoId",
                        column: x => x.QuartoId,
                        principalTable: "Quarto",
                        principalColumn: "QuartoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuartoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Quarto_QuartoId",
                        column: x => x.QuartoId,
                        principalTable: "Quarto",
                        principalColumn: "QuartoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemQuarto",
                columns: table => new
                {
                    ItemQuartoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantidadeQuarto = table.Column<int>(type: "int", nullable: false),
                    QuartoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemQuarto", x => x.ItemQuartoId);
                    table.ForeignKey(
                        name: "FK_ItemQuarto_Quarto_QuartoId",
                        column: x => x.QuartoId,
                        principalTable: "Quarto",
                        principalColumn: "QuartoId");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeArmazem = table.Column<int>(type: "int", nullable: false),
                    ItemQuartoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_ItemQuarto_ItemQuartoId",
                        column: x => x.ItemQuartoId,
                        principalTable: "ItemQuarto",
                        principalColumn: "ItemQuartoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_QuartoId",
                table: "Client",
                column: "QuartoId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_QuartoId",
                table: "Employee",
                column: "QuartoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemQuarto_QuartoId",
                table: "ItemQuarto",
                column: "QuartoId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemQuartoId",
                table: "Items",
                column: "ItemQuartoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemQuarto");

            migrationBuilder.DropTable(
                name: "Quarto");
        }
    }
}
