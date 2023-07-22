using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace milk_in_liters_api.Migrations
{
    public partial class dbcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    member_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    member_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    aadhar_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.member_Id);
                });

            migrationBuilder.CreateTable(
                name: "milks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    liters = table.Column<int>(type: "int", nullable: false),
                    totalliters = table.Column<int>(type: "int", nullable: false),
                    member_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_milks", x => x.id);
                    table.ForeignKey(
                        name: "FK_milks_members_member_Id",
                        column: x => x.member_Id,
                        principalTable: "members",
                        principalColumn: "member_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_milks_member_Id",
                table: "milks",
                column: "member_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "milks");

            migrationBuilder.DropTable(
                name: "members");
        }
    }
}
