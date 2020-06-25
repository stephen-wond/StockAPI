using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PortfolioEndpoint.Migrations
{
    public partial class renamingIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Users_UserId",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Symbols",
                table: "Symbols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

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
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TelegramId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Symbols");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Stocks");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ExternalId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SymbolId",
                table: "Symbols",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Stocks",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Symbols",
                table: "Symbols",
                column: "SymbolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "StockId");

            migrationBuilder.InsertData(
                table: "Symbols",
                columns: new[] { "SymbolId", "Name", "Ticker" },
                values: new object[,]
                {
                    { 1, "Tesla", "TSLA" },
                    { 2, "PayPoint PLC", "PAY.L" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ExternalId", "FirstName", "LastContact", "LastName" },
                values: new object[,]
                {
                    { 1, 0, "Carson", new DateTime(2020, 6, 15, 16, 14, 40, 14, DateTimeKind.Local).AddTicks(2400), "Alexander" },
                    { 2, 0, "Meredith", new DateTime(2020, 6, 15, 16, 14, 40, 18, DateTimeKind.Local).AddTicks(4887), "Alonso" },
                    { 3, 0, "Arturo", new DateTime(2020, 6, 15, 16, 14, 40, 18, DateTimeKind.Local).AddTicks(4965), "Anand" }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockId", "ChangeAlert", "InitialPrice", "IsActive", "LastAlertPrice", "SymbolId", "TargetPrice", "UserId" },
                values: new object[] { 1, 5, 1234.0, true, 1234.0, 1, 1235.0, 1 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockId", "ChangeAlert", "InitialPrice", "IsActive", "LastAlertPrice", "SymbolId", "TargetPrice", "UserId" },
                values: new object[] { 2, 5, 1234.0, true, 1234.0, 2, 1235.0, 1 });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "StockId", "ChangeAlert", "InitialPrice", "IsActive", "LastAlertPrice", "SymbolId", "TargetPrice", "UserId" },
                values: new object[] { 3, 1, 4321.0, true, 4321.0, 1, 4322.0, 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Users_UserId",
                table: "Stocks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Users_UserId",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Symbols",
                table: "Symbols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "StockId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Symbols",
                keyColumn: "SymbolId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Symbols",
                keyColumn: "SymbolId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SymbolId",
                table: "Symbols");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Stocks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "TelegramId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Symbols",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Symbols",
                table: "Symbols",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

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
                columns: new[] { "Id", "FirstName", "LastContact", "LastName", "TelegramId" },
                values: new object[,]
                {
                    { 1, "Carson", new DateTime(2020, 6, 15, 15, 53, 26, 635, DateTimeKind.Local).AddTicks(2921), "Alexander", 0 },
                    { 2, "Meredith", new DateTime(2020, 6, 15, 15, 53, 26, 640, DateTimeKind.Local).AddTicks(144), "Alonso", 0 },
                    { 3, "Arturo", new DateTime(2020, 6, 15, 15, 53, 26, 640, DateTimeKind.Local).AddTicks(229), "Anand", 0 }
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

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Users_UserId",
                table: "Stocks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
