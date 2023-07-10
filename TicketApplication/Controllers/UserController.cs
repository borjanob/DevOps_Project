using Microsoft.AspNetCore.Mvc;
using TicketApplication.Data.Repository.IRepository;
using TicketApplication.Models.Models;
using TicketApplication.Services.Interface;

namespace TicketApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        public IActionResult Index()
        {
            List< ApplicationUser > allUsers= _userService.GetAll().ToList();

            return View(allUsers);
        }
    }
}
