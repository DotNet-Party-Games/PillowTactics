using Microsoft.EntityFrameworkCore.Migrations;

namespace PillowFight.Api.Migrations
{
    public partial class UsernameUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Players_UserName",
                table: "Players",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_UserName",
                table: "Players");
        }
    }
}
