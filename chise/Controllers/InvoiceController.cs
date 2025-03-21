using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;
using chise.Models;
using chise.Models;

namespace chise.Controllers
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

            ViewBag.Total = $"có  {model.Quantity} với giá {model.UnitPrice}"; // Gọi Index() thay vì CalculateTotal()
            return View();
        }
    }
}