using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieInformation.Data.Migrations
{
    public partial class addmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    fullName = table.Column<string>(nullable: true),
                    nickName = table.Column<string>(nullable: true),
                    placeOfBirth = table.Column<string>(nullable: true),
                    gender = table.Column<int>(nullable: false),
                    birthDay = table.Column<DateTime>(nullable: true),
                    imageUrl = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    displayName = table.Column<string>(nullable: true),
                    imageUrl = table.Column<string>(nullable: true),
                    author = table.Column<string>(nullable: true),
                    times = table.Column<string>(nullable: true),
                    userScore = table.Column<double>(nullable: false),
                    trailerUrl = table.Column<string>(nullable: true),
                    descriptions = table.Column<string>(nullable: true),
                    dateRelease = table.Column<DateTime>(nullable: false),
                    modifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    movieId = table.Column<Guid>(nullable: false),
                    actorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => x.id);
                    table.ForeignKey(
                        name: "FK_MovieActor_Actor_actorId",
                        column: x => x.actorId,
                        principalTable: "Actor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActor_Movie_movieId",
                        column: x => x.movieId,
                        principalTable: "Movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCategory",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    moviesId = table.Column<Guid>(nullable: false),
                    categorieId = table.Column<Guid>(nullable: false),
                    Categoryid = table.Column<Guid>(nullable: true),
                    Movieid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategory", x => x.id);
                    table.ForeignKey(
                        name: "FK_MovieCategory_Category_Categoryid",
                        column: x => x.Categoryid,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieCategory_Movie_Movieid",
                        column: x => x.Movieid,
                        principalTable: "Movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_actorId",
                table: "MovieActor",
                column: "actorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_movieId",
                table: "MovieActor",
                column: "movieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategory_Categoryid",
                table: "MovieCategory",
                column: "Categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategory_Movieid",
                table: "MovieCategory",
                column: "Movieid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.DropTable(
                name: "MovieCategory");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}
