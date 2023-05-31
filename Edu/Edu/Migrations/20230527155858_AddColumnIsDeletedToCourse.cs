using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edu.Migrations
{
    public partial class AddColumnIsDeletedToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsDeleted",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Courses");
        }
    }
}
