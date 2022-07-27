using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventureWork.Migrations
{
    public partial class EDH4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShiftId",
                table: "Shift",
                newName: "ShiftID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShiftID",
                table: "Shift",
                newName: "ShiftId");
        }
    }
}
