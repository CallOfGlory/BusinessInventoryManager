namespace WebApplication2.Models
{
    public class SupplierModel
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ContactPerson { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Website { get; set; }
        public string? Notes { get; set; }
        public decimal? CreditLimit { get; set; }
        public int PaymentTermDays { get; set; } = 30;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public BusinessModel? Business { get; set; }
        public ICollection<PurchaseOrderModel> PurchaseOrders { get; set; } = new List<PurchaseOrderModel>();
    }
}
