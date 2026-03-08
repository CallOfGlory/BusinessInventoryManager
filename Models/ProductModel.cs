namespace WebApplication2.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BusinessId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string SKU { get; set; } = string.Empty;
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public int Quantity { get; set; }
        public int MinStockLevel { get; set; } = 5;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int? SupplierId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public BusinessModel Business { get; set; } = null!;
        public UserModel User { get; set; } = null!;
        public SupplierModel? Supplier { get; set; }
        public ICollection<TransactionModel> Transactions { get; set; } = new List<TransactionModel>();
    }
}
