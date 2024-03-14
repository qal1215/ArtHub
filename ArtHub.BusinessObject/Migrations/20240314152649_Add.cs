using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtHub.BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BanReason",
                table: "Artworks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BanStatus",
                table: "Artworks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BanReason",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "BanStatus",
                table: "Artworks");
        }
    }
}
