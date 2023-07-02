using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "Description", "Duration", "Name", "ReleaseYear", "TicketPrice" },
                values: new object[,]
                {
                    { 10, 4, "First Movie", 100, "Movie 15", 2010, 50.0 },
                    { 20, 4, "Second Movie", 120, "Movie 25", 2000, 70.0 },
                    { 30, 4, "Third Movie", 80, "Movie 35", 2001, 10.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "Description", "Duration", "Name", "ReleaseYear", "TicketPrice" },
                values: new object[,]
                {
                    { 1, 4, "First Movie", 100, "Movie 1", 2010, 50.0 },
                    { 2, 4, "Second Movie", 120, "Movie 2", 2000, 70.0 },
                    { 3, 4, "Third Movie", 80, "Movie 3", 2001, 10.0 }
                });
        }
    }
}
