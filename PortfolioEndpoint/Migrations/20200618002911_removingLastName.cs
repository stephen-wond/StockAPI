using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PortfolioEndpoint.Migrations
{
    public partial class removingLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "LastContact",
                value: new DateTime(2020, 6, 18, 1, 29, 10, 226, DateTimeKind.Local).AddTicks(1982));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "LastContact",
                value: new DateTime(2020, 6, 18, 1, 29, 10, 231, DateTimeKind.Local).AddTicks(311));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "LastContact",
                value: new DateTime(2020, 6, 18, 1, 29, 10, 231, DateTimeKind.Local).AddTicks(492));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "LastContact", "LastName" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 17, 51, 371, DateTimeKind.Local).AddTicks(4903), "Alexander" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "LastContact", "LastName" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 17, 51, 376, DateTimeKind.Local).AddTicks(5994), "Alonso" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "LastContact", "LastName" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 17, 51, 376, DateTimeKind.Local).AddTicks(6108), "Anand" });
        }
    }
}
