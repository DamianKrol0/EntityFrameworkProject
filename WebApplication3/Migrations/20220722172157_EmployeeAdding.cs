using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureWork.Migrations
{
    public partial class EmployeeAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalIDNumber = table.Column<int>(type: "int", nullable: false),
                    LoginID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationLevel = table.Column<int>(type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Flag = table.Column<int>(type: "int", nullable: false),
                    VacationHours = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    SickLeaveHours = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    SalariedFlag = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CurrentFlag = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.BusinessEntityID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
