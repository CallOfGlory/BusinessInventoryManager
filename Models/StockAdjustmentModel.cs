namespace WebApplication2.Models
{
    public class StockAdjustmentModel
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public AdjustmentType Type { get; set; }
        public int QuantityBefore { get; set; }
        public int QuantityAdjusted { get; set; }
        public int QuantityAfter { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string? ReferenceNumber { get; set; }
        public string? Notes { get; set; }
        public DateTime AdjustmentDate { get; set; } = DateTime.UtcNow;

        // Navigation
        public BusinessModel? Business { get; set; }
        public ProductModel? Product { get; set; }
        public UserModel? User { get; set; }
    }

    public enum AdjustmentType
    {
        Increase = 0,
        Decrease = 1,
        Correction = 2,
        Damage = 3,
        Loss = 4,
        Return = 5,
        Expired = 6,
        Theft = 7,
        Transfer = 8
    }
}
