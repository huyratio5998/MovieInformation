using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieInformation.Migrations
{
    public partial class updateMovieFavoritesModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "MovieFavorites");

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "MovieFavorites",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userName",
                table: "MovieFavorites");

            migrationBuilder.AddColumn<Guid>(
                name: "userId",
                table: "MovieFavorites",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
