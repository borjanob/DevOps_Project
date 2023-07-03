using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicketApplication.Data.Repository.IRepository;
using TicketApplication.Models;
using TicketApplication.Models.Models;

namespace TicketApplication.Areas.Customer.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Movie> _movieRepository;
        public HomeController(ILogger<HomeController> logger, IRepository<Movie> repository)
        {
            _logger = logger;
            _movieRepository = repository;
        }

        public IActionResult Index()
        {
            IEnumerable<Movie> movies = _movieRepository.GetAll();
            return View(movies);
        }

        public IActionResult Details(int? id)
        {
            Movie movie = _movieRepository.Get(x => x.Id == id);
            return View(movie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}