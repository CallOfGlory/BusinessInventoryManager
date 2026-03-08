namespace WebApplication2.Models
{
    public class BusinessModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Currency { get; set; } = "USD";
        public string CurrencySymbol { get; set; } = "$";
        public bool IsActive { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public UserModel? User { get; set; }
        public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
        public ICollection<TransactionModel> Transactions { get; set; } = new List<TransactionModel>();
    }
}
