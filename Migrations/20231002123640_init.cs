using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetingApp2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeetingItemStatuses",
                columns: table => new
                {
                    MeetingItemStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingItemStatuses", x => x.MeetingItemStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetingsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MeetingType = table.Column<int>(type: "int", nullable: false),
                    MeetingItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MeetingsID);
                });

            migrationBuilder.CreateTable(
                name: "MeetingItems",
                columns: table => new
                {
                    MeetingItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonResponsible = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingItemStatus = table.Column<int>(type: "int", nullable: false),
                    MeetingItemStatusesMeetingItemStatusId = table.Column<int>(type: "int", nullable: true),
                    MeetingsID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingItems", x => x.MeetingItemId);
                    table.ForeignKey(
                        name: "FK_MeetingItems_MeetingItemStatuses_MeetingItemStatusesMeetingItemStatusId",
                        column: x => x.MeetingItemStatusesMeetingItemStatusId,
                        principalTable: "MeetingItemStatuses",
                        principalColumn: "MeetingItemStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetingItems_Meetings_MeetingsID",
                        column: x => x.MeetingsID,
                        principalTable: "Meetings",
                        principalColumn: "MeetingsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeetingTypes",
                columns: table => new
                {
                    MeetingTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MeetingTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingsID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingTypes", x => x.MeetingTypeId);
                    table.ForeignKey(
                        name: "FK_MeetingTypes_Meetings_MeetingsID",
                        column: x => x.MeetingsID,
                        principalTable: "Meetings",
                        principalColumn: "MeetingsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_MeetingItemStatusesMeetingItemStatusId",
                table: "MeetingItems",
                column: "MeetingItemStatusesMeetingItemStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingItems_MeetingsID",
                table: "MeetingItems",
                column: "MeetingsID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingTypes_MeetingsID",
                table: "MeetingTypes",
                column: "MeetingsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetingItems");

            migrationBuilder.DropTable(
                name: "MeetingTypes");

            migrationBuilder.DropTable(
                name: "MeetingItemStatuses");

            migrationBuilder.DropTable(
                name: "Meetings");
        }
    }
}
