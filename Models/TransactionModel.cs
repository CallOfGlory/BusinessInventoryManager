namespace WebApplication2.Models
{
    public enum TransactionType
    {
        Purchase,   // Закупівля товару (надходження на склад)
        Sale,       // Продаж товару
        Adjustment  // Коригування залишків
    }

    public class TransactionModel
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int ProductId { get; set; }
        public TransactionType Type { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }
        public string? Notes { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public BusinessModel? Business { get; set; }
        public ProductModel? Product { get; set; }
    }
}
