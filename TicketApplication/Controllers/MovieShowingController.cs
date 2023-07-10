using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketApplication.Data.Repository.Imp;
using TicketApplication.Data.Repository.IRepository;
using TicketApplication.Models;
using TicketApplication.Models.Models;
using TicketApplication.Services.Interface;

namespace TicketApplication.Controllers
{
    public class MovieShowingController : Controller
    {
        private readonly IMovieShowingService _movieShowingService;
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<CinemaHall> _cinemaHallRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;


        public MovieShowingController(IMovieShowingService movieShowingRepository, IRepository<Movie> movieRepository, IRepository<CinemaHall> cinemaRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
        {
            _movieShowingService = movieShowingRepository;
            _movieRepository = movieRepository;
            _cinemaHallRepository = cinemaRepository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;

        }


        public IActionResult Index()
        {
            List<MovieShowing> movies = _movieShowingService.GetAll().ToList();

            return View(movies);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> movieList = _movieRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            IEnumerable<SelectListItem> hallsList = _cinemaHallRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.movieList = movieList;
            ViewBag.hallsList = hallsList;
            //ViewData["CategoryList"] = CategoryList;
            //CREATE
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieShowing obj)
        {
            if (obj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int cinemaHallCapacity = _cinemaHallRepository.Get(x => x.Id == obj.CinemaHallId).Capacity;
                //obj.AvailableSeats = cinemaHallCapacity;
                _movieShowingService.Add(obj, cinemaHallCapacity);
                _movieShowingService.Save();
                TempData["sucess"] = "Movie showing was added!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? Id)
        {

            IEnumerable<SelectListItem> movieList = _movieRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            IEnumerable<SelectListItem> hallsList = _cinemaHallRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.movieList = movieList;
            ViewBag.hallsList = hallsList;

            MovieShowing? ToEdit = _movieShowingService.Get(x => x.Id == Id);
            if (ToEdit == null)
            {
                return NotFound();
            }
            return View(ToEdit);
        }

        [HttpPost]
        public IActionResult Edit(MovieShowing obj)
        {
            if (obj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _movieShowingService.Update(obj);
                _movieShowingService.Save();
                TempData["sucess"] = "Movie showing was updated!";
                return RedirectToAction("Index");
            }
            return View(obj.Id);
        }

        public IActionResult Delete(int? Id)
        {

            MovieShowing? ToDelete = _movieShowingService.Get(x => x.Id == Id);
            if (ToDelete == null)
            {
                return NotFound();
            }
            return View(ToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(MovieShowing obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            _movieShowingService.Remove(obj);
            _movieShowingService.Save();
            TempData["sucess"] = "Movie showing was removed!";
            return RedirectToAction("Index");

        }


        public IActionResult AddToCard(int id)
        {
            return View();
        }
        public IActionResult Export()
        {

            /*IEnumerable<SelectListItem> CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.CategoryList = CategoryList;*/

            List<Category> categories = _categoryRepository.GetAll().ToList();

            return View(categories);
        }

        [HttpPost, ActionName("Export")]
        public IActionResult ExportPost(int categoryId)
        {

            List<MovieShowing> showingsToExport = _movieShowingService.GetAll().Where(x => x.Movie.CategoryId == categoryId).ToList();


            string fileName = "export.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";


            using (var workBook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workBook.Worksheets.Add("All Orders");

                worksheet.Cell(1, 1).Value = "Movie showing Id";
                worksheet.Cell(1, 2).Value = "Movie Name";
                worksheet.Cell(1, 3).Value = "Cinema hall name";
                worksheet.Cell(1, 4).Value = "Available seats";

                for (int i = 1; i <= showingsToExport.Count(); i++)
                {
                    var item = showingsToExport[i - 1];

                    worksheet.Cell(i + 1, 1).Value = item.Id.ToString();
                    worksheet.Cell(i + 1, 2).Value = item.Movie.Name;
                    worksheet.Cell(i + 1, 3).Value = item.CinemaHall.Name;
                    worksheet.Cell(i + 1, 4).Value = item.AvailableSeats.ToString();

                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);

                    var content = stream.ToArray();

                    return File(content, contentType, fileName);
                }


            }
            return RedirectToAction("Index", "Home");
        }
    }
}
