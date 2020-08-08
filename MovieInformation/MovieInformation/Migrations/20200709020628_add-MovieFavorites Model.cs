using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieInformation.Migrations
{
    public partial class addMovieFavoritesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieFavorites",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    movieId = table.Column<Guid>(nullable: false),
                    userId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieFavorites", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieFavorites");
        }
    }
}
