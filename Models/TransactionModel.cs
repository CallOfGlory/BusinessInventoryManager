namespace WebApplication2.Models
{
    public enum TransactionType
    {
        Purchase,    // Buying inventory (expense)
        Sale,        // Selling to customer (income)
        Return,      // Customer return (refund)
        Adjustment,  // Manual stock adjustment
        WriteOff     // Damaged/expired goods
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
        public string Notes { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public BusinessModel Business { get; set; } = null!;
        public ProductModel Product { get; set; } = null!;
    }
}
