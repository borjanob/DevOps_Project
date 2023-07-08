using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class addNewMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CategoryId", "Description", "Duration", "ImageUrl", "Name", "ReleaseYear", "TicketPrice" },
                values: new object[] { 6, 4, "A feature documentary exploring how one man's brilliance, hubris and relentless drive changed the nature of war forever, led to the deaths of hundreds of thousands of people and unleashed mass hysteria, and how, subsequently, the same man's attempts to co.", 120, "seed_images/oppenheimer.jpg", "Oppenheimer", 2023, 15.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
