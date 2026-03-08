namespace WebApplication2.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Notes { get; set; }
        public decimal TotalPurchases { get; set; } = 0;
        public int TotalOrders { get; set; } = 0;
        public int LoyaltyPoints { get; set; } = 0;
        public CustomerTier Tier { get; set; } = CustomerTier.Regular;
        public bool IsActive { get; set; } = true;
        public DateTime? LastPurchaseDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public BusinessModel? Business { get; set; }
        public ICollection<TransactionModel> Transactions { get; set; } = new List<TransactionModel>();
    }

    public enum CustomerTier
    {
        Regular = 0,
        Bronze = 1,
        Silver = 2,
        Gold = 3,
        Platinum = 4
    }
}
