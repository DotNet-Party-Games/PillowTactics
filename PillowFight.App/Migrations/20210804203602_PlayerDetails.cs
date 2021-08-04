using Microsoft.EntityFrameworkCore.Migrations;

namespace PillowFight.App.Migrations
{
    public partial class PlayerDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "PillowFight",
                table: "Players",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealName",
                schema: "PillowFight",
                table: "Players",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Role",
                schema: "PillowFight",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "PillowFight",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RealName",
                schema: "PillowFight",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Role",
                schema: "PillowFight",
                table: "Players");
        }
    }
}
