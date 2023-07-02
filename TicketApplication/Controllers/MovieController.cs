using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using TicketApplication.Data.Repository.IRepository;
using TicketApplication.Models.Models;
using TicketApplication.Models.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace TicketApplication.Areas.Customer.Controllers
{
    public class MovieController : Controller
    {
        private IRepository<Movie> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MovieController(IRepository<Movie> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Movie> movies = _repository.GetAll().ToList();
          
            return View(movies);
        }

        public IActionResult Upsert(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            ViewBag.CategoryList = CategoryList;
            //ViewData["CategoryList"] = CategoryList;

            /* MovieVM movieVM = new()
             {
                 CategoryList = _unitOfWork.CategoryRepository.GetAll().Select(x => new SelectListItem
                 {
                     Text = x.Name,
                     Value = x.Id.ToString()
                 }),
                 Movie = new Movie()
         };*/

            //CREATE
            if (id == null || id==0)
            {
                return View();
            }

            //UPDATE
            else
            {
                Movie? ToEdit = _repository.Get(x => x.Id == id);
                return View(ToEdit);
            }

        }

        [HttpPost]
        public IActionResult Upsert(Movie obj, IFormFile? file)
        {
            if(obj == null) {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                _repository.Add(obj);
                _repository.Save();
                TempData["sucess"] = "Movie was added!";
                return RedirectToAction("Index");
            }
            return View();
        }

      /*  public IActionResult Edit(int? Id)
        {
            Movie? ToEdit  = _repository.Get(x =>x.Id == Id);
            if (ToEdit == null)
            { 
                return NotFound();
            }
            return View(ToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie obj)
        {
            if (obj == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.Update(obj);
                _repository.Save();
                TempData["sucess"] = "Movie was updated!";
                return RedirectToAction("Index");
            }
            return View(obj.Id);
        }*/

        public IActionResult Delete(int? Id)
        {

            Movie? ToDelete = _repository.Get(x => x.Id == Id);
            if (ToDelete == null)
            {
                return NotFound();
            }
            return View(ToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(Movie obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
                _repository.Remove(obj);
                _repository.Save();
                TempData["sucess"] = "Movie was removed!";
                return RedirectToAction("Index");

        }


    }
}
