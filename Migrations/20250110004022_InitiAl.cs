using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitiAl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buffet",
                columns: table => new
                {
                    BuffetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buffet", x => x.BuffetId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    UnityMeasure = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UnityRecipe = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StockMin = table.Column<int>(type: "int", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false),
                    LastModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientID);
                });

            migrationBuilder.CreateTable(
                name: "Prato",
                columns: table => new
                {
                    PratoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(900)", maxLength: 900, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prato", x => x.PratoId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SupplierAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    SupplierPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierEmail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "BuffetPrato",
                columns: table => new
                {
                    BuffetId = table.Column<int>(type: "int", nullable: false),
                    PratosPratoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuffetPrato", x => new { x.BuffetId, x.PratosPratoId });
                    table.ForeignKey(
                        name: "FK_BuffetPrato_Buffet_BuffetId",
                        column: x => x.BuffetId,
                        principalTable: "Buffet",
                        principalColumn: "BuffetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuffetPrato_Prato_PratosPratoId",
                        column: x => x.PratosPratoId,
                        principalTable: "Prato",
                        principalColumn: "PratoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComposicaoPrato",
                columns: table => new
                {
                    ComposicaoPratoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientID = table.Column<int>(type: "int", nullable: false),
                    PratoID = table.Column<int>(type: "int", nullable: false),
                    IngredientQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComposicaoPrato", x => x.ComposicaoPratoID);
                    table.ForeignKey(
                        name: "FK_ComposicaoPrato_Ingredient_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredient",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComposicaoPrato_Prato_PratoID",
                        column: x => x.PratoID,
                        principalTable: "Prato",
                        principalColumn: "PratoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuffetPrato_PratosPratoId",
                table: "BuffetPrato",
                column: "PratosPratoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComposicaoPrato_IngredientID",
                table: "ComposicaoPrato",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_ComposicaoPrato_PratoID",
                table: "ComposicaoPrato",
                column: "PratoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuffetPrato");

            migrationBuilder.DropTable(
                name: "ComposicaoPrato");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Buffet");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Prato");
        }
    }
}
