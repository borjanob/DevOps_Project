using Microsoft.AspNetCore.Mvc;
using TicketApplication.Models.Models;
using TicketApplication.Models.Relationship;
using TicketApplication.Services.Interface;

namespace TicketApplication.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMovieShowingService _movieShowingService;

        public ShoppingCartController(IShoppingCartService service, IMovieShowingService movieShowingService)
        {
            _shoppingCartService = service;
            _movieShowingService = movieShowingService;

        }

        public IActionResult Index(int id)
        {
            ShoppingCart cart = _shoppingCartService.Get(x => x.Id == id);
            return View(cart);
        }

        public IActionResult AddToCart(int id) {

            MovieShowing movieShowing = _movieShowingService.Get(x => x.Id == id);

            ShowingInShoppingCart showingInCart = new()
            {
                MovieShowing = movieShowing,
                MovieShowingId = id,
                Quantity = 0
            };
            return View(showingInCart);
        
        }

        [HttpPost,ActionName("AddToCart")]
        public IActionResult AddToCartPost(ShowingInShoppingCart showingInShoppingCart)
        {


            return View(showingInShoppingCart);
        }
    }
}
