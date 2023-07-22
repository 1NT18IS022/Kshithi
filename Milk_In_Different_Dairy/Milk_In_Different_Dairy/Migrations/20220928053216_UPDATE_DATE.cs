using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Milk_In_Different_Dairy.Migrations
{
    public partial class UPDATE_DATE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "data",
                table: "Daily_records",
                newName: "date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "Daily_records",
                newName: "data");
        }
    }
}
