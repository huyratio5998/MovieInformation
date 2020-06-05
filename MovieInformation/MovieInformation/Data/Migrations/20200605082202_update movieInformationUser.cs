using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieInformation.Data.Migrations
{
    public partial class updatemovieInformationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Session_Id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Guest_session_id",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guest_session_id",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Session_Id",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
