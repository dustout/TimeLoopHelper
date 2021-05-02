using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeLoopHelper.Migrations
{
    public partial class AddedStartAndEndToChallenge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValidOn",
                table: "Challenges",
                newName: "ValidOnStartUtc");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidOnEndUtc",
                table: "Challenges",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidOnEndUtc",
                table: "Challenges");

            migrationBuilder.RenameColumn(
                name: "ValidOnStartUtc",
                table: "Challenges",
                newName: "ValidOn");
        }
    }
}
