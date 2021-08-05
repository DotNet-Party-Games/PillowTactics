using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PillowFight.Repositories.Enumerations;
using System.Collections.Generic;

namespace PillowFight.Api.Migrations
{
    public partial class newinitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
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
                    TorsoSlotItemId = table.Column<int>(type: "integer", nullable: false),
                    TorsoSlotItem = table.Column<string>(type: "text", nullable: true),
                    MainHandSlotItemId = table.Column<int>(type: "integer", nullable: false),
                    MainHandSlotItem = table.Column<string>(type: "text", nullable: true),
                    ArmsSlotItemId = table.Column<int>(type: "integer", nullable: false),
                    ArmsSlotItem = table.Column<string>(type: "text", nullable: true),
                    HeadSlotItemId = table.Column<int>(type: "integer", nullable: false),
                    HeadSlotItem = table.Column<string>(type: "text", nullable: true),
                    LegsSlotItemId = table.Column<int>(type: "integer", nullable: false),
                    LegsSlotItem = table.Column<string>(type: "text", nullable: true),
                    OffHandSlotSlotItemId = table.Column<int>(type: "integer", nullable: false),
                    OffHandSlotItem = table.Column<string>(type: "text", nullable: true),
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
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Losses = table.Column<int>(type: "integer", nullable: false),
                    Wins = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    RealName = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
