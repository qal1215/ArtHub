using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtHub.BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class Update_Order_OrderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Members_BuyerAccountId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BuyerAccountId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BuyerAccountId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "BuyerIn",
                table: "Orders",
                newName: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Members_BuyerId",
                table: "Orders",
                column: "BuyerId",
                principalTable: "Members",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Members_BuyerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "BuyerId",
                table: "Orders",
                newName: "BuyerIn");

            migrationBuilder.AddColumn<int>(
                name: "BuyerAccountId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerAccountId",
                table: "Orders",
                column: "BuyerAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Members_BuyerAccountId",
                table: "Orders",
                column: "BuyerAccountId",
                principalTable: "Members",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
