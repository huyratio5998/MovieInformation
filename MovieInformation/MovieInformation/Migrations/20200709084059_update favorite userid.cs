using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieInformation.Migrations
{
    public partial class updatefavoriteuserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userName",
                table: "MovieFavorites");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "MovieFavorites",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "MovieFavorites");

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "MovieFavorites",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
