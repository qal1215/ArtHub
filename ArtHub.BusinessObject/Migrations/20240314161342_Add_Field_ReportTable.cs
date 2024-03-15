using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtHub.BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class Add_Field_ReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReportReason",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportReason",
                table: "Reports");
        }
    }
}
