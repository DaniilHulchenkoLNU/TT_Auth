using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TT_Auth.Data.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 4, 18, 47, 56, 682, DateTimeKind.Local).AddTicks(8975), new DateTime(2024, 6, 24, 18, 47, 56, 682, DateTimeKind.Local).AddTicks(8914) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 6, 29, 18, 47, 56, 682, DateTimeKind.Local).AddTicks(8982), new DateTime(2024, 6, 24, 18, 47, 56, 682, DateTimeKind.Local).AddTicks(8981) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 24, 18, 47, 56, 682, DateTimeKind.Local).AddTicks(8993), new DateTime(2024, 6, 24, 18, 47, 56, 682, DateTimeKind.Local).AddTicks(8992) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 24, 18, 47, 56, 682, DateTimeKind.Local).AddTicks(9003), new DateTime(2024, 6, 24, 18, 47, 56, 682, DateTimeKind.Local).AddTicks(9001) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 7, 4, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6500), new DateTime(2024, 6, 24, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6452) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 6, 29, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6507), new DateTime(2024, 6, 24, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6506) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 24, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6516), new DateTime(2024, 6, 24, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6515) });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 9, 24, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6525), new DateTime(2024, 6, 24, 14, 26, 53, 564, DateTimeKind.Local).AddTicks(6524) });
        }
    }
}
