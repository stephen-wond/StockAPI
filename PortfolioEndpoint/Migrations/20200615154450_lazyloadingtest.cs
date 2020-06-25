using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PortfolioEndpoint.Migrations
{
    public partial class lazyloadingtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 16, 44, 49, 902, DateTimeKind.Local).AddTicks(4932));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 16, 44, 49, 906, DateTimeKind.Local).AddTicks(4400));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 16, 44, 49, 906, DateTimeKind.Local).AddTicks(4466));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 16, 35, 33, 247, DateTimeKind.Local).AddTicks(746));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 16, 35, 33, 250, DateTimeKind.Local).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "LastContact",
                value: new DateTime(2020, 6, 15, 16, 35, 33, 250, DateTimeKind.Local).AddTicks(8005));
        }
    }
}
