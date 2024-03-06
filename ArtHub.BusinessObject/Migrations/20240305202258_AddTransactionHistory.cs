using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtHub.BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Members",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "HistoryTransaction",
                columns: table => new
                {
                    HistoryTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BeforeTransactionBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AfterTransactionBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MemberAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryTransaction", x => x.HistoryTransactionId);
                    table.ForeignKey(
                        name: "FK_HistoryTransaction_Members_MemberAccountId",
                        column: x => x.MemberAccountId,
                        principalTable: "Members",
                        principalColumn: "AccountId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryTransaction_MemberAccountId",
                table: "HistoryTransaction",
                column: "MemberAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryTransaction");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Members");
        }
    }
}
