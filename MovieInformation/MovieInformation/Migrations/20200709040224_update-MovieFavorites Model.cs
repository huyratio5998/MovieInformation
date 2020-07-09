using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieInformation.Migrations
{
    public partial class updateMovieFavoritesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "movieId",
                table: "MovieFavorites",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "isFavorites",
                table: "MovieFavorites",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFavorites",
                table: "MovieFavorites");

            migrationBuilder.AlterColumn<Guid>(
                name: "movieId",
                table: "MovieFavorites",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
