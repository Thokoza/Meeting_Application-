using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingApp2.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingTypes_Meetings_MeetingsID",
                table: "MeetingTypes");

            migrationBuilder.DropIndex(
                name: "IX_MeetingTypes_MeetingsID",
                table: "MeetingTypes");

            migrationBuilder.DropColumn(
                name: "MeetingsID",
                table: "MeetingTypes");

            migrationBuilder.AddColumn<int>(
                name: "MeetingTypesMeetingTypeId",
                table: "Meetings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_MeetingTypesMeetingTypeId",
                table: "Meetings",
                column: "MeetingTypesMeetingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_MeetingTypes_MeetingTypesMeetingTypeId",
                table: "Meetings",
                column: "MeetingTypesMeetingTypeId",
                principalTable: "MeetingTypes",
                principalColumn: "MeetingTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_MeetingTypes_MeetingTypesMeetingTypeId",
                table: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_Meetings_MeetingTypesMeetingTypeId",
                table: "Meetings");

            migrationBuilder.DropColumn(
                name: "MeetingTypesMeetingTypeId",
                table: "Meetings");

            migrationBuilder.AddColumn<Guid>(
                name: "MeetingsID",
                table: "MeetingTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeetingTypes_MeetingsID",
                table: "MeetingTypes",
                column: "MeetingsID");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingTypes_Meetings_MeetingsID",
                table: "MeetingTypes",
                column: "MeetingsID",
                principalTable: "Meetings",
                principalColumn: "MeetingsID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
