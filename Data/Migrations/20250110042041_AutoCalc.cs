using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AutoCalc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PricePerDatepricePD_id",
                table: "Sazonalidade",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PricePerDatepricePD_id",
                table: "Promos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PricePerDatepricePD_id",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sazonalidade_PricePerDatepricePD_id",
                table: "Sazonalidade",
                column: "PricePerDatepricePD_id");

            migrationBuilder.CreateIndex(
                name: "IX_Promos_PricePerDatepricePD_id",
                table: "Promos",
                column: "PricePerDatepricePD_id");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PricePerDatepricePD_id",
                table: "Events",
                column: "PricePerDatepricePD_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_PricePerDate_PricePerDatepricePD_id",
                table: "Events",
                column: "PricePerDatepricePD_id",
                principalTable: "PricePerDate",
                principalColumn: "pricePD_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Promos_PricePerDate_PricePerDatepricePD_id",
                table: "Promos",
                column: "PricePerDatepricePD_id",
                principalTable: "PricePerDate",
                principalColumn: "pricePD_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sazonalidade_PricePerDate_PricePerDatepricePD_id",
                table: "Sazonalidade",
                column: "PricePerDatepricePD_id",
                principalTable: "PricePerDate",
                principalColumn: "pricePD_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_PricePerDate_PricePerDatepricePD_id",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Promos_PricePerDate_PricePerDatepricePD_id",
                table: "Promos");

            migrationBuilder.DropForeignKey(
                name: "FK_Sazonalidade_PricePerDate_PricePerDatepricePD_id",
                table: "Sazonalidade");

            migrationBuilder.DropIndex(
                name: "IX_Sazonalidade_PricePerDatepricePD_id",
                table: "Sazonalidade");

            migrationBuilder.DropIndex(
                name: "IX_Promos_PricePerDatepricePD_id",
                table: "Promos");

            migrationBuilder.DropIndex(
                name: "IX_Events_PricePerDatepricePD_id",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PricePerDatepricePD_id",
                table: "Sazonalidade");

            migrationBuilder.DropColumn(
                name: "PricePerDatepricePD_id",
                table: "Promos");

            migrationBuilder.DropColumn(
                name: "PricePerDatepricePD_id",
                table: "Events");
        }
    }
}
