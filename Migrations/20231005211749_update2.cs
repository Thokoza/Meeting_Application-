using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingApp2.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingItems_Meetings_MeetingsID",
                table: "MeetingItems");

            migrationBuilder.DropIndex(
                name: "IX_MeetingItems_MeetingsID",
                table: "MeetingItems");

            migrationBuilder.DropColumn(
                name: "MeetingItem",
                table: "Meetings");

            migrationBuilder.AlterColumn<Guid>(
                name: "MeetingsID",
                table: "MeetingItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MeetingsID1",
                table: "MeetingItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_MeetingsID1",
                table: "MeetingItems",
                column: "MeetingsID1");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingItems_Meetings_MeetingsID1",
                table: "MeetingItems",
                column: "MeetingsID1",
                principalTable: "Meetings",
                principalColumn: "MeetingsID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingItems_Meetings_MeetingsID1",
                table: "MeetingItems");

            migrationBuilder.DropIndex(
                name: "IX_MeetingItems_MeetingsID1",
                table: "MeetingItems");

            migrationBuilder.DropColumn(
                name: "MeetingsID1",
                table: "MeetingItems");

            migrationBuilder.AddColumn<int>(
                name: "MeetingItem",
                table: "Meetings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "MeetingsID",
                table: "MeetingItems",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_MeetingsID",
                table: "MeetingItems",
                column: "MeetingsID");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingItems_Meetings_MeetingsID",
                table: "MeetingItems",
                column: "MeetingsID",
                principalTable: "Meetings",
                principalColumn: "MeetingsID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
