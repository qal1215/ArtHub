using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtHub.BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class Update_ReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsResolved",
                table: "Reports",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ResolveDescription",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsResolved",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "ResolveDescription",
                table: "Reports");
        }
    }
}
