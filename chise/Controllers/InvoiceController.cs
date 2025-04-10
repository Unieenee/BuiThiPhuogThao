using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;
using chise.Models;

namespace chise.Controllers
{
    public class InvoiceController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(InvoiceModel model)
        {
            ViewBag.TotalPrice = model.CalculateTotal();
            return View(model);
        }
    }
}