using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Milk_In_Different_Dairy.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dairys",
                columns: table => new
                {
                    Dairy_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dairy_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dairys", x => x.Dairy_id);
                });

            migrationBuilder.CreateTable(
                name: "Daily_records",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    liters = table.Column<float>(type: "real", nullable: false),
                    fat = table.Column<float>(type: "real", nullable: false),
                    data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dairy_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily_records", x => x.id);
                    table.ForeignKey(
                        name: "FK_Daily_records_Dairys_Dairy_Id",
                        column: x => x.Dairy_Id,
                        principalTable: "Dairys",
                        principalColumn: "Dairy_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Daily_records_Dairy_Id",
                table: "Daily_records",
                column: "Dairy_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Daily_records");

            migrationBuilder.DropTable(
                name: "Dairys");
        }
    }
}
