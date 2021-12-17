using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManager.DAL.Migrations
{
    public partial class ClientLocationadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clientLocationId",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDelete = table.Column<int>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: true),
                    updatedAt = table.Column<DateTime>(nullable: true),
                    createdBy = table.Column<string>(maxLength: 250, nullable: true),
                    updatedBy = table.Column<string>(maxLength: 250, nullable: true),
                    clientLocationName = table.Column<string>(type: "NVARCHAR(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientLocations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_clientLocationId",
                table: "Projects",
                column: "clientLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_ClientLocations_clientLocationId",
                table: "Projects",
                column: "clientLocationId",
                principalTable: "ClientLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_ClientLocations_clientLocationId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "ClientLocations");

            migrationBuilder.DropIndex(
                name: "IX_Projects_clientLocationId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "clientLocationId",
                table: "Projects");
        }
    }
}
