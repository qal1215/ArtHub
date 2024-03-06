using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtHub.BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class AddArtworkPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtworkId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ArtworkId",
                table: "Posts",
                column: "ArtworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Artworks_ArtworkId",
                table: "Posts",
                column: "ArtworkId",
                principalTable: "Artworks",
                principalColumn: "ArtworkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Artworks_ArtworkId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ArtworkId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ArtworkId",
                table: "Posts");
        }
    }
}
