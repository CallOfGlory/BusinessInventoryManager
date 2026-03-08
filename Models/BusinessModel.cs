namespace WebApplication2.Models
{
    public class BusinessModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Currency { get; set; } = "USD";
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public UserModel User { get; set; } = null!;
        public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
        public ICollection<TransactionModel> Transactions { get; set; } = new List<TransactionModel>();
    }
}
