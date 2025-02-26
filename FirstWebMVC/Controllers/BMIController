using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class BMIController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(BMI ps)
        {
            ps.BMIValue = GetBMIValue(ps.Height, ps.Weight);
            ps.BMICategory = GetBMICategory(ps.BMIValue);
            string strOutput = "Chiều Cao: " + ps.Height + " cm - Cân Nặng: " + ps.Weight + " kg - Chỉ số BMI: " + ps.BMIValue.ToString("F2") + " - Phân loại BMI: " + ps.BMICategory;
            ViewBag.infoPerson = strOutput;
            return View(ps);
        }

        private float GetBMIValue(float height, float weight)
        {
            // Chuyển đổi chiều cao từ cm sang m
            float heightInMeters = height / 100f;
            return weight / (heightInMeters * heightInMeters);
        }

        private string GetBMICategory(float bmi)
        {
            if (bmi < 18.5)
                return "Thiếu cân";
            else if (bmi >= 18.5 && bmi < 24.9)
                return "Bình thường";
            else if (bmi >= 25 && bmi < 29.9)
                return "Thừa cân";
            else
                return "Béo phì";
        }
    }
}