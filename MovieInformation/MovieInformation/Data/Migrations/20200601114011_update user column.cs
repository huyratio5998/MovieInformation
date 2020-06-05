using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieInformation.Data.Migrations
{
    public partial class updateusercolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Session_Id",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Session_Id",
                table: "AspNetUsers");
        }
    }
}
