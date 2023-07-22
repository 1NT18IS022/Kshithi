using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace milk_in_liters_api.Migrations
{
    public partial class type_chnage_of_milk_from_int_to_float : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalliters",
                table: "milks");

            migrationBuilder.AlterColumn<float>(
                name: "liters",
                table: "milks",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<float>(
                name: "total_liters",
                table: "milks",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_liters",
                table: "milks");

            migrationBuilder.AlterColumn<int>(
                name: "liters",
                table: "milks",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "totalliters",
                table: "milks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
