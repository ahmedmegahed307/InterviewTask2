using Microsoft.EntityFrameworkCore.Migrations;

namespace AFS_.NET_Developer_Test.Migrations
{
    public partial class addedIsActiveForDeleteAndUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Contents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Contents");
        }
    }
}
