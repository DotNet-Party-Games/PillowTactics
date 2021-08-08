using Microsoft.EntityFrameworkCore.Migrations;

namespace PillowFight.Api.Migrations
{
    public partial class NullablePlayerEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Items_MainHandSlotItemId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Items_TorsoSlotItemId",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "TorsoSlotItemId",
                table: "Characters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "OffHandSlotSlotItemId",
                table: "Characters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MainHandSlotItemId",
                table: "Characters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "LegsSlotItemId",
                table: "Characters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "HeadSlotItemId",
                table: "Characters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ArmsSlotItemId",
                table: "Characters",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Items_MainHandSlotItemId",
                table: "Characters",
                column: "MainHandSlotItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Items_TorsoSlotItemId",
                table: "Characters",
                column: "TorsoSlotItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Items_MainHandSlotItemId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Items_TorsoSlotItemId",
                table: "Characters");

            migrationBuilder.AlterColumn<int>(
                name: "TorsoSlotItemId",
                table: "Characters",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OffHandSlotSlotItemId",
                table: "Characters",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainHandSlotItemId",
                table: "Characters",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LegsSlotItemId",
                table: "Characters",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HeadSlotItemId",
                table: "Characters",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArmsSlotItemId",
                table: "Characters",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Items_MainHandSlotItemId",
                table: "Characters",
                column: "MainHandSlotItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Items_TorsoSlotItemId",
                table: "Characters",
                column: "TorsoSlotItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
