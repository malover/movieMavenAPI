using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CollectionsAndRelatedFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieRelations");

            migrationBuilder.AddColumn<string>(
                name: "ParentMovieId",
                table: "Movies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ImgUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieCollection",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "TEXT", nullable: false),
                    CollectionId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCollection", x => new { x.MovieId, x.CollectionId });
                    table.ForeignKey(
                        name: "FK_MovieCollection_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCollection_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ParentMovieId",
                table: "Movies",
                column: "ParentMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCollection_CollectionId",
                table: "MovieCollection",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Movies_ParentMovieId",
                table: "Movies",
                column: "ParentMovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Movies_ParentMovieId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "MovieCollection");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ParentMovieId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ParentMovieId",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "MovieRelations",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "TEXT", nullable: false),
                    RelatedMovieId = table.Column<string>(type: "TEXT", nullable: false),
                    RelationshipType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRelations", x => new { x.MovieId, x.RelatedMovieId });
                    table.ForeignKey(
                        name: "FK_MovieRelations_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieRelations_Movies_RelatedMovieId",
                        column: x => x.RelatedMovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieRelations_RelatedMovieId",
                table: "MovieRelations",
                column: "RelatedMovieId");
        }
    }
}
