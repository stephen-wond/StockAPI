using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace PortfolioEndpoint.Migrations
{
    public partial class testingFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
