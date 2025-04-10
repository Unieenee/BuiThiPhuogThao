using Microsoft.AspNetCore.Mvc;
using chise.Models;
using System.Text.Encodings.Web;

namespace chise.Controllers
{
    public class GradeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(GradeModel model)
        {
            ViewBag.FinalGrade = model.CalculateFinalGrade();
            return View(model);
        }
    }
}