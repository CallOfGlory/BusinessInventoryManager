using WebApplication2.Models;

namespace WebApplication2.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        // Active Business Info
        public int? ActiveBusinessId { get; set; }
        public string? ActiveBusinessName { get; set; }
        public string CurrencySymbol { get; set; } = "$";
        public bool HasActiveBusiness { get; set; }

        // Summary Statistics
        public int TotalProducts { get; set; }
        public int LowStockProducts { get; set; }
        public double TotalInventoryValue { get; set; }
        public double TotalSalesToday { get; set; }
        public double TotalSalesThisMonth { get; set; }
        public double ProfitThisMonth { get; set; }
        public int TransactionsToday { get; set; }
        public int TransactionsThisMonth { get; set; }

        // Recent Activity
        public IEnumerable<TransactionViewModel> RecentTransactions { get; set; } = new List<TransactionViewModel>();
        public IEnumerable<LowStockProductViewModel> LowStockItems { get; set; } = new List<LowStockProductViewModel>();

        // User Info
        public string Username { get; set; } = string.Empty;
        public int TotalBusinesses { get; set; }
    }

    public class TransactionViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Notes { get; set; }
    }

    public class LowStockProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Category { get; set; }
        public int Quantity { get; set; }
        public int? MinStockLevel { get; set; }
    }
}
