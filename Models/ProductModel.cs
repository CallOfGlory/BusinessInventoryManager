namespace WebApplication2.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? BusinessId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? SKU { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public int Quantity { get; set; }
        public int? MinStockLevel { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public UserModel? User { get; set; }
        public BusinessModel? Business { get; set; }
        public ICollection<TransactionModel> Transactions { get; set; } = new List<TransactionModel>();

        // Calculated properties
        public double ProfitPerUnit => SalePrice - PurchasePrice;
        public double TotalInventoryValue => PurchasePrice * Quantity;
        public double PotentialProfit => ProfitPerUnit * Quantity;
        public bool IsLowStock => MinStockLevel.HasValue && Quantity <= MinStockLevel.Value;
    }
}
