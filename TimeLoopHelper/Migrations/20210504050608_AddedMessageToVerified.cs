using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeLoopHelper.Migrations
{
    public partial class AddedMessageToVerified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "VerifiedTimeLoops",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "VerifiedTimeLoops");
        }
    }
}
