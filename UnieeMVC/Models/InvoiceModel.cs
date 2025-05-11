namespace UnieeMVC.Models
{    public class InvoiceModel
    {
        public int Quantity { get; set; } // Số lượng
        public double Price { get; set; } // Đơn giá

        public double CalculateTotal()
        {
            return Quantity * Price;
        }
    }
}