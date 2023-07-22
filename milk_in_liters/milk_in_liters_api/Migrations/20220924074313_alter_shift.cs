using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace milk_in_liters_api.Migrations
{
    public partial class alter_shift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "milks");

            migrationBuilder.AddColumn<int>(
                name: "shift",
                table: "milks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "shift",
                table: "milks");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "milks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
