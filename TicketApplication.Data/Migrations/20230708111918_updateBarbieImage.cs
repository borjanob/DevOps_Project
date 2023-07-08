using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateBarbieImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/seed_images/barbie.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "seed_images/barbie.jpg");
        }
    }
}
