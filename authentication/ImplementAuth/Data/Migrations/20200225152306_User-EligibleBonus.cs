using Microsoft.EntityFrameworkCore.Migrations;

namespace ImplementAuth.Data.Migrations
{
    public partial class UserEligibleBonus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EligibleBonus",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EligibleBonus",
                table: "AspNetUsers");
        }
    }
}
