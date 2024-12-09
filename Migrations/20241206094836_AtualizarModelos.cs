using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffTestModel_JobTestModel_JobTestJob_ID",
                table: "StaffTestModel");

            migrationBuilder.DropIndex(
                name: "IX_StaffTestModel_JobTestJob_ID",
                table: "StaffTestModel");

            migrationBuilder.DropColumn(
                name: "JobTestJob_ID",
                table: "StaffTestModel");

            migrationBuilder.AlterColumn<string>(
                name: "Staff_Name",
                table: "StaffTestModel",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Job_ID",
                table: "StaffTestModel",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Staff_Id",
                table: "StaffTestModel",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Staff_Name",
                table: "StaffTestModel",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Job_ID",
                table: "StaffTestModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Staff_Id",
                table: "StaffTestModel",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "JobTestJob_ID",
                table: "StaffTestModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StaffTestModel_JobTestJob_ID",
                table: "StaffTestModel",
                column: "JobTestJob_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffTestModel_JobTestModel_JobTestJob_ID",
                table: "StaffTestModel",
                column: "JobTestJob_ID",
                principalTable: "JobTestModel",
                principalColumn: "Job_ID");
        }
    }
}
