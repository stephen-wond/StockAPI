using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PortfolioEndpoint.Migrations
{
    public partial class addingSymbolFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 16, 17, 37, 70, DateTimeKind.Local).AddTicks(6866));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 16, 17, 37, 76, DateTimeKind.Local).AddTicks(7266));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 16, 17, 37, 76, DateTimeKind.Local).AddTicks(7335));

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_SymbolId",
                table: "Stocks",
                column: "SymbolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Symbols_SymbolId",
                table: "Stocks",
                column: "SymbolId",
                principalTable: "Symbols",
                principalColumn: "SymbolId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Symbols_SymbolId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_SymbolId",
                table: "Stocks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 16, 14, 40, 14, DateTimeKind.Local).AddTicks(2400));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 16, 14, 40, 18, DateTimeKind.Local).AddTicks(4887));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 16, 14, 40, 18, DateTimeKind.Local).AddTicks(4965));
        }
    }
}
