using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.DAL.Migrations
{
    public partial class ProjectModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Projects",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Projects",
                type: "NVARCHAR(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Projects");
        }
    }
}
