using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureWork.Migrations
{
    public partial class EPH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeePayHistory",
                columns: table => new
                {
                    BusinessEntityId = table.Column<int>(type: "int", nullable: false),
                    RateChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayFrequency = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePayHistory", x => new { x.BusinessEntityId, x.RateChangeDate });
                    table.ForeignKey(
                        name: "FK_EmployeePayHistory_Employee_BusinessEntityId",
                        column: x => x.BusinessEntityId,
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeePayHistory");
        }
    }
}
