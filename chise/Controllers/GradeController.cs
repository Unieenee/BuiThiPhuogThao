using Microsoft.AspNetCore.Mvc;
using chise.Models;
using System.Text.Encodings.Web;
using chise.Models;

namespace chise.Controllers
{
    public class GradeController : Controller
    {
        public IActionResult Index(double A, double B, double C)
        {
            var gradeModel = new GradeModel { A = A, B = B, C = C };
            double finalGrade = gradeModel.Index(); // Gọi phương thức Index thay vì CalculateFinalGrade
            string classification = gradeModel.GetClassification();

            ViewBag.Result = $"Điểm trung bình: {finalGrade:F2} - Xếp loại: {classification}";
            return View();
        }
    }
}