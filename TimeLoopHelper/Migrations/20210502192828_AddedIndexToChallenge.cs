using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeLoopHelper.Migrations
{
    public partial class AddedIndexToChallenge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Challenges_ValidOnEndUtc",
                table: "Challenges",
                column: "ValidOnEndUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Challenges_ValidOnStartUtc",
                table: "Challenges",
                column: "ValidOnStartUtc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Challenges_ValidOnEndUtc",
                table: "Challenges");

            migrationBuilder.DropIndex(
                name: "IX_Challenges_ValidOnStartUtc",
                table: "Challenges");
        }
    }
}
