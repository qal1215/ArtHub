using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtHub.BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateArtwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArtworkPrice",
                table: "Artworks");

            migrationBuilder.RenameColumn(
                name: "ArtworkName",
                table: "Artworks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ArtworkImage",
                table: "Artworks",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "ArtworkDescription",
                table: "Artworks",
                newName: "Description");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Artworks",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Artworks",
                newName: "ArtworkName");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Artworks",
                newName: "ArtworkImage");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Artworks",
                newName: "ArtworkDescription");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Artworks",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "ArtworkPrice",
                table: "Artworks",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
