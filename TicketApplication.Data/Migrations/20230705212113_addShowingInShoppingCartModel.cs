using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class addShowingInShoppingCartModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_movieShowings_MovieShowingId",
                table: "shoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_shoppingCarts_MovieShowingId",
                table: "shoppingCarts");

            migrationBuilder.CreateTable(
                name: "showingsInShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    MovieShowingId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_showingsInShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_showingsInShoppingCart_movieShowings_MovieShowingId",
                        column: x => x.MovieShowingId,
                        principalTable: "movieShowings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_showingsInShoppingCart_shoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "shoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_showingsInShoppingCart_MovieShowingId",
                table: "showingsInShoppingCart",
                column: "MovieShowingId");

            migrationBuilder.CreateIndex(
                name: "IX_showingsInShoppingCart_ShoppingCartId",
                table: "showingsInShoppingCart",
                column: "ShoppingCartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "showingsInShoppingCart");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingCarts_MovieShowingId",
                table: "shoppingCarts",
                column: "MovieShowingId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_movieShowings_MovieShowingId",
                table: "shoppingCarts",
                column: "MovieShowingId",
                principalTable: "movieShowings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
