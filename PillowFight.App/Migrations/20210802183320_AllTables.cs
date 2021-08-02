using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PillowFight.Repositories.Enumerations;

namespace PillowFight.App.Migrations
{
    public partial class AllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PillowFight");

            migrationBuilder.CreateTable(
                name: "Characters",
                schema: "PillowFight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StatusEffects = table.Column<List<StatusEffectEnum>>(type: "integer[]", nullable: true),
                    Class = table.Column<int>(type: "integer", nullable: false),
                    Strength = table.Column<int>(type: "integer", nullable: false),
                    Dexterity = table.Column<int>(type: "integer", nullable: false),
                    Constitution = table.Column<int>(type: "integer", nullable: false),
                    Intelligence = table.Column<int>(type: "integer", nullable: false),
                    Wisdom = table.Column<int>(type: "integer", nullable: false),
                    ArmsSlotItemId = table.Column<int>(type: "integer", nullable: false),
                    ArmsSlotItem = table.Column<string>(type: "text", nullable: true),
                    HeadSlotItemId = table.Column<int>(type: "integer", nullable: false),
                    HeadSlotItem = table.Column<string>(type: "text", nullable: true),
                    LegsSlotItemId = table.Column<int>(type: "integer", nullable: false),
                    LegsSlotItem = table.Column<string>(type: "text", nullable: true),
                    MainHandSlotItemId = table.Column<int>(type: "integer", nullable: false),
                    MainHandSlotItem = table.Column<string>(type: "text", nullable: true),
                    OffHandSlotSlotItemId = table.Column<int>(type: "integer", nullable: false),
                    OffHandSlotItem = table.Column<string>(type: "text", nullable: true),
                    TosoSlotItemId = table.Column<int>(type: "integer", nullable: false),
                    TorsoSlotItem = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    PlayerId = table.Column<int>(type: "integer", nullable: true),
                    Player = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "PillowFight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StatusEffects = table.Column<List<StatusEffectEnum>>(type: "integer[]", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Defense = table.Column<int>(type: "integer", nullable: true),
                    Attack = table.Column<int>(type: "integer", nullable: true),
                    Range = table.Column<int>(type: "integer", nullable: true),
                    Cost = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                schema: "PillowFight",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Losses = table.Column<int>(type: "integer", nullable: false),
                    Wins = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters",
                schema: "PillowFight");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "PillowFight");

            migrationBuilder.DropTable(
                name: "Players",
                schema: "PillowFight");
        }
    }
}
