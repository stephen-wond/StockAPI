using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioEndpoint.Migrations
{
    public partial class refrshing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "LastContact",
                value: new DateTime(2020, 6, 21, 18, 53, 46, 384, DateTimeKind.Local).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "LastContact",
                value: new DateTime(2020, 6, 21, 18, 53, 46, 389, DateTimeKind.Local).AddTicks(439));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "LastContact",
                value: new DateTime(2020, 6, 21, 18, 53, 46, 389, DateTimeKind.Local).AddTicks(522));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "LastContact",
                value: new DateTime(2020, 6, 18, 15, 8, 8, 210, DateTimeKind.Local).AddTicks(3452));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "LastContact",
                value: new DateTime(2020, 6, 18, 15, 8, 8, 217, DateTimeKind.Local).AddTicks(2532));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "LastContact",
                value: new DateTime(2020, 6, 18, 15, 8, 8, 217, DateTimeKind.Local).AddTicks(2676));
        }
    }
}
