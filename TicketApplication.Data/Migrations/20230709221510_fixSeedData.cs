using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "movieShowings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableSeats", "StartTime" },
                values: new object[] { 150, new DateTime(2023, 7, 10, 0, 15, 10, 382, DateTimeKind.Local).AddTicks(4674) });

            migrationBuilder.UpdateData(
                table: "movieShowings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableSeats", "StartTime" },
                values: new object[] { 100, new DateTime(2023, 7, 10, 0, 15, 10, 382, DateTimeKind.Local).AddTicks(4716) });

            migrationBuilder.UpdateData(
                table: "movieShowings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableSeats", "StartTime" },
                values: new object[] { 200, new DateTime(2023, 7, 10, 0, 15, 10, 382, DateTimeKind.Local).AddTicks(4718) });

            migrationBuilder.UpdateData(
                table: "movieShowings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableSeats", "StartTime" },
                values: new object[] { 150, new DateTime(2023, 7, 10, 0, 15, 10, 382, DateTimeKind.Local).AddTicks(4720) });

            migrationBuilder.UpdateData(
                table: "movieShowings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvailableSeats", "StartTime" },
                values: new object[] { 100, new DateTime(2023, 7, 10, 0, 15, 10, 382, DateTimeKind.Local).AddTicks(4721) });

            migrationBuilder.UpdateData(
                table: "movieShowings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvailableSeats", "StartTime" },
                values: new object[] { 200, new DateTime(2023, 7, 10, 0, 15, 10, 382, DateTimeKind.Local).AddTicks(4723) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "movieShowings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AvailableSeats", "StartTime" },
                values: new object[] { 0, new DateTime(2023, 7, 10, 0, 10, 47, 870, DateTimeKind.Local).AddTicks(3041) });

            migrationBuilder.UpdateData(
                table: "movieShowings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AvailableSeats", "StartTime" },
                values: new object[] { 0, new DateTime(2023, 7, 10, 0, 10, 47, 870, DateTimeKind.Local).AddTicks(3079) });

            migrationBuilder.UpdateData(
                table: "movieShowings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AvailableSeats", "StartTime" },
                values: new object[] { 0, new DateTime(2023, 7, 10, 0, 10, 47, 870, DateTimeKind.Local).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "movieShowings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AvailableSeats", "StartTime" },
                values: new object[] { 0, new DateTime(2023, 7, 10, 0, 10, 47, 870, DateTimeKind.Local).AddTicks(3082) });

            migrationBuilder.UpdateData(
                table: "movieShowings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AvailableSeats", "StartTime" },
                values: new object[] { 0, new DateTime(2023, 7, 10, 0, 10, 47, 870, DateTimeKind.Local).AddTicks(3084) });

            migrationBuilder.UpdateData(
                table: "movieShowings",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AvailableSeats", "StartTime" },
                values: new object[] { 0, new DateTime(2023, 7, 10, 0, 10, 47, 870, DateTimeKind.Local).AddTicks(3115) });
        }
    }
}
