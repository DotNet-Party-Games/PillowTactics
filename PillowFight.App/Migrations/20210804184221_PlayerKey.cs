using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PillowFight.App.Migrations
{
    public partial class PlayerKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                schema: "PillowFight",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                schema: "PillowFight",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "PillowFight",
                table: "Players",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                schema: "PillowFight",
                table: "Players",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                schema: "PillowFight",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "PillowFight",
                table: "Players",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                schema: "PillowFight",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                schema: "PillowFight",
                table: "Players",
                column: "PlayerId");
        }
    }
}
