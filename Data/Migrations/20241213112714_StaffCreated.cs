using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReserveSystem.Migrations
{
    /// <inheritdoc />
    public partial class StaffCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "StaffModel",
                columns: table => new
                {
                    Staff_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Staff_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Staff_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Staff_Phone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Staff_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job_Id = table.Column<int>(type: "int", nullable: false),
                    DrivingLicenseGrades = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverLicenseExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffModel", x => x.Staff_Id);
                });

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "StaffModel");

           
        }
    }
}
