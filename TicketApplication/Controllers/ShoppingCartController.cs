using Microsoft.AspNetCore.Mvc;

namespace TicketApplication.Controllers
{
    public class ShoppingCartController : Controller
    {


        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
