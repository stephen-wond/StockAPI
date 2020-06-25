using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PortfolioEndpoint.Migrations
{
    public partial class removingForignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Symbols_SymbolId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_SymbolId",
                table: "Stocks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 15, 53, 26, 635, DateTimeKind.Local).AddTicks(2921));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 15, 53, 26, 640, DateTimeKind.Local).AddTicks(144));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 15, 53, 26, 640, DateTimeKind.Local).AddTicks(229));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 15, 38, 8, 213, DateTimeKind.Local).AddTicks(849));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 15, 38, 8, 216, DateTimeKind.Local).AddTicks(9186));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 15, 38, 8, 216, DateTimeKind.Local).AddTicks(9258));

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_SymbolId",
                table: "Stocks",
                column: "SymbolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Symbols_SymbolId",
                table: "Stocks",
                column: "SymbolId",
                principalTable: "Symbols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
