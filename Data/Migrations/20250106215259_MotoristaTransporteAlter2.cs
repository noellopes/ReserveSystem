using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class MotoristaTransporteAlter2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotoristaTransporteStaff");

            migrationBuilder.DropTable(
                name: "MotoristaTransporteTransporte");

            migrationBuilder.CreateIndex(
                name: "IX_MotoristaTransporte_StaffId",
                table: "MotoristaTransporte",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_MotoristaTransporte_TransporteId",
                table: "MotoristaTransporte",
                column: "TransporteId");

            migrationBuilder.AddForeignKey(
                name: "FK_MotoristaTransporte_Staff_StaffId",
                table: "MotoristaTransporte",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MotoristaTransporte_Transporte_TransporteId",
                table: "MotoristaTransporte",
                column: "TransporteId",
                principalTable: "Transporte",
                principalColumn: "TransporteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotoristaTransporte_Staff_StaffId",
                table: "MotoristaTransporte");

            migrationBuilder.DropForeignKey(
                name: "FK_MotoristaTransporte_Transporte_TransporteId",
                table: "MotoristaTransporte");

            migrationBuilder.DropIndex(
                name: "IX_MotoristaTransporte_StaffId",
                table: "MotoristaTransporte");

            migrationBuilder.DropIndex(
                name: "IX_MotoristaTransporte_TransporteId",
                table: "MotoristaTransporte");

            migrationBuilder.CreateTable(
                name: "MotoristaTransporteStaff",
                columns: table => new
                {
                    MotoristaTransporteId = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoristaTransporteStaff", x => new { x.MotoristaTransporteId, x.StaffId });
                    table.ForeignKey(
                        name: "FK_MotoristaTransporteStaff_MotoristaTransporte_MotoristaTransporteId",
                        column: x => x.MotoristaTransporteId,
                        principalTable: "MotoristaTransporte",
                        principalColumn: "MotoristaTransporteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotoristaTransporteStaff_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotoristaTransporteTransporte",
                columns: table => new
                {
                    MotoristaTransporteId = table.Column<int>(type: "int", nullable: false),
                    TransporteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoristaTransporteTransporte", x => new { x.MotoristaTransporteId, x.TransporteId });
                    table.ForeignKey(
                        name: "FK_MotoristaTransporteTransporte_MotoristaTransporte_MotoristaTransporteId",
                        column: x => x.MotoristaTransporteId,
                        principalTable: "MotoristaTransporte",
                        principalColumn: "MotoristaTransporteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotoristaTransporteTransporte_Transporte_TransporteId",
                        column: x => x.TransporteId,
                        principalTable: "Transporte",
                        principalColumn: "TransporteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MotoristaTransporteStaff_StaffId",
                table: "MotoristaTransporteStaff",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_MotoristaTransporteTransporte_TransporteId",
                table: "MotoristaTransporteTransporte",
                column: "TransporteId");
        }
    }
}
