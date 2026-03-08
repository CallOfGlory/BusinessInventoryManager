namespace WebApplication2.Models
{
    public class SavedReportModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BusinessId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ReportType Type { get; set; }
        public string? FilterSettings { get; set; } // JSON with filters
        public bool IsScheduled { get; set; } = false;
        public string? ScheduleCron { get; set; }
        public string? EmailRecipients { get; set; }
        public DateTime? LastRunAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public UserModel? User { get; set; }
        public BusinessModel? Business { get; set; }
    }

    public enum ReportType
    {
        SalesSummary = 0,
        InventoryStatus = 1,
        ProfitLoss = 2,
        TopProducts = 3,
        LowStock = 4,
        CustomerAnalysis = 5,
        SupplierPerformance = 6,
        TransactionHistory = 7,
        TaxReport = 8,
        Custom = 9
    }
}
