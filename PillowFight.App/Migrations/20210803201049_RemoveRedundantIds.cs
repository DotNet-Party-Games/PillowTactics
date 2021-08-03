using Microsoft.EntityFrameworkCore.Migrations;

namespace PillowFight.App.Migrations
{
    public partial class RemoveRedundantIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TosoSlotItemId",
                schema: "PillowFight",
                table: "Characters",
                newName: "TorsoSlotItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TorsoSlotItemId",
                schema: "PillowFight",
                table: "Characters",
                newName: "TosoSlotItemId");
        }
    }
}
