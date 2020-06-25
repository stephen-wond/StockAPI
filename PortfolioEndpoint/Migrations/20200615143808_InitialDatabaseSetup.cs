using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PortfolioEndpoint.Migrations
{
    public partial class InitialDatabaseSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Symbols",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticker = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelegramId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LastContact = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    SymbolId = table.Column<int>(nullable: false),
                    InitialPrice = table.Column<double>(nullable: false),
                    TargetPrice = table.Column<double>(nullable: true),
                    ChangeAlert = table.Column<int>(nullable: false),
                    LastAlertPrice = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Symbols_SymbolId",
                        column: x => x.SymbolId,
                        principalTable: "Symbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, "Carson", new DateTime(2020, 6, 15, 15, 38, 8, 213, DateTimeKind.Local).AddTicks(849), "Alexander", 0 },
                    { 2, "Meredith", new DateTime(2020, 6, 15, 15, 38, 8, 216, DateTimeKind.Local).AddTicks(9186), "Alonso", 0 },
                    { 3, "Arturo", new DateTime(2020, 6, 15, 15, 38, 8, 216, DateTimeKind.Local).AddTicks(9258), "Anand", 0 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_SymbolId",
                table: "Stocks",
                column: "SymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_UserId",
                table: "Stocks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Symbols");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
