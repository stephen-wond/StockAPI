using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioAPI.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Symbols",
                columns: new[] { "Id", "Name", "Ticker" },
                values: new object[,]
                {
                    { 1, "Tesla", "TSLA" },
                    { 2, "PayPoint PLC", "PAY.L" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastContact", "LastName" },
                values: new object[,]
                {
                    { 1, "Carson", new DateTime(2020, 6, 12, 19, 3, 45, 376, DateTimeKind.Local).AddTicks(2938), "Alexander" },
                    { 2, "Meredith", new DateTime(2020, 6, 12, 19, 3, 45, 380, DateTimeKind.Local).AddTicks(972), "Alonso" },
                    { 3, "Arturo", new DateTime(2020, 6, 12, 19, 3, 45, 380, DateTimeKind.Local).AddTicks(1237), "Anand" }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "ChangeAlert", "InitialPrice", "IsActive", "LastAlertPrice", "SymbolId", "TargetPrice", "UserId" },
                values: new object[] { 1, 5, 1234.0, true, 1234.0, 1, 1235.0, 1 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "ChangeAlert", "InitialPrice", "IsActive", "LastAlertPrice", "SymbolId", "TargetPrice", "UserId" },
                values: new object[] { 2, 5, 1234.0, true, 1234.0, 2, 1235.0, 1 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "ChangeAlert", "InitialPrice", "IsActive", "LastAlertPrice", "SymbolId", "TargetPrice", "UserId" },
                values: new object[] { 3, 1, 4321.0, true, 4321.0, 1, 4322.0, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Symbols",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Symbols",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
