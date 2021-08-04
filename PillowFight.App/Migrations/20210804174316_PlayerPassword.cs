using Microsoft.EntityFrameworkCore.Migrations;

namespace PillowFight.App.Migrations
{
    public partial class PlayerPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "PillowFight",
                table: "Players",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                schema: "PillowFight",
                table: "Players");
        }
    }
}
