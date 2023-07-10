using DocumentFormat.OpenXml.Vml;
using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using TicketApplication.Models.Models;
using TicketApplication.Services.Interface;

namespace TicketApplication.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {

            List<Order>? orders = _orderService.GetAll().ToList();

            return View(orders);
        }

        public IActionResult Details()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            List<Order>? orders = _orderService.GetAllForUser(userId).ToList();

            ViewBag.totalSum = _orderService.GetTotalSumForUser(userId);

            return View(orders);
        }


        public IActionResult Confirm() {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            bool orderCompleted = _orderService.CompleteOrder(userId);

            if (orderCompleted) {

                TempData["message"] = "Order completed successfully!";
                return RedirectToAction("Index", "Home");
            }

            TempData["message"] = "Order completed successfully!";
            return RedirectToAction("Index", "Home");
        }


        public IActionResult CreateInvoice(int id)
        {
            Order toExport = _orderService.Get(x => x.Id == id);
            var templatePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Invoice.txt");

            var document = DocumentModel.Load(templatePath);



            document.Content.Replace("{{OrderNumber}}", toExport.Id.ToString());
            document.Content.Replace("{{CostumerEmail}}", toExport.applicationUser.Email);

            StringBuilder sb = new StringBuilder();

            
            document.Content.Replace("{{TotalPrice}}", "$" + toExport.totalSum.ToString());

            var stream = new MemoryStream();

            document.Save(stream, new PdfSaveOptions());


            return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportInvoice.pdf");
        }

    }
}
