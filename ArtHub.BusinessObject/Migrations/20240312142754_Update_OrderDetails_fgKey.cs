using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtHub.BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class Update_OrderDetails_fgKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "OrderDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");
        }
    }
}
