using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureWork.Migrations
{
    public partial class EDH3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDepartmentHistory",
                table: "EmployeeDepartmentHistory");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDepartmentHistory_BusinessEntityID",
                table: "EmployeeDepartmentHistory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDepartmentHistory",
                table: "EmployeeDepartmentHistory",
                columns: new[] { "BusinessEntityID", "StartDate", "DepartmentId", "ShiftID" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmentHistory_DepartmentId",
                table: "EmployeeDepartmentHistory",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDepartmentHistory",
                table: "EmployeeDepartmentHistory");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDepartmentHistory_DepartmentId",
                table: "EmployeeDepartmentHistory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDepartmentHistory",
                table: "EmployeeDepartmentHistory",
                columns: new[] { "DepartmentId", "ShiftID", "StartDate", "BusinessEntityID" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartmentHistory_BusinessEntityID",
                table: "EmployeeDepartmentHistory",
                column: "BusinessEntityID");
        }
    }
}
