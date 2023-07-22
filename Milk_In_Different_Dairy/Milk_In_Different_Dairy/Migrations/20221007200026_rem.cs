using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Milk_In_Different_Dairy.Migrations
{
    public partial class rem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

           
            migrationBuilder.DropColumn(
                name: "fat",
                table: "Daily_records");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<float>(
                name: "fat",
                table: "Daily_records",
                type: "real",
                nullable: false,
                defaultValue: 0f);

           
        }
    }
}
