using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePrecoColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "ExcursaoModel",
                type: "FLOAT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Preco",
                table: "ExcursaoModel",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "FLOAT");
        }
    }
}
