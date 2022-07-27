using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureWork.Migrations
{
    public partial class EDH1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Department",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDepartmentHistory",
                columns: table => new
                {
                    BusinessEntityID = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ShiftID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartmentHistory", x => new { x.DepartmentId, x.ShiftID, x.StartDate, x.BusinessEntityID });
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Employee_BusinessEntityID",
                        column: x => x.BusinessEntityID,
                        principalTable: "Employee",
                        principalColumn: "BusinessEntityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartmentHistory_Shift_ShiftID",
                        column: x => x.ShiftID,
                        principalTable: "Shift",
                        principalColumn: "ShiftId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmentHistory_BusinessEntityID",
                table: "EmployeeDepartmentHistory",
                column: "BusinessEntityID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmentHistory_ShiftID",
                table: "EmployeeDepartmentHistory",
                column: "ShiftID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDepartmentHistory");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "Department",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
