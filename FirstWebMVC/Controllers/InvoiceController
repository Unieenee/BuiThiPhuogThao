using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index(double quantity = 0, double unitPrice = 0)
        {
            var model = new InvoiceModel
            {
                Quantity = quantity,
                UnitPrice = unitPrice
            };

            ViewBag.Total = model.Index().ToString("N0") + " VND"; // Gọi Index() thay vì CalculateTotal()
            return View();
        }
    }
}