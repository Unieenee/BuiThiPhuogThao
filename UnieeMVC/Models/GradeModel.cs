
namespace  UnieeMVC.Models
{
      public class GradeModel
    {
        public double A { get; set; } // Điểm giữa kỳ
        public double B { get; set; } // Điểm chuyên cần
        public double C { get; set; } // Điểm cuối kỳ

        public double CalculateFinalGrade()
        {
            return (A * 0.3) + (B * 0.2) + (C * 0.5);
        }
    }
}