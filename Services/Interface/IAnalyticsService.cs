using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public class DashboardSummary
    {
        public int TotalProducts { get; set; }
        public int LowStockProducts { get; set; }
        public double TotalInventoryValue { get; set; }
        public double TotalSalesToday { get; set; }
        public double TotalSalesThisMonth { get; set; }
        public double ProfitThisMonth { get; set; }
        public int TransactionsToday { get; set; }
        public int TransactionsThisMonth { get; set; }
        public IEnumerable<TransactionModel> RecentTransactions { get; set; } = new List<TransactionModel>();
        public IEnumerable<ProductModel> LowStockItems { get; set; } = new List<ProductModel>();
    }

    public class ProfitAnalytics
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalRevenue { get; set; }
        public double TotalCost { get; set; }
        public double GrossProfit { get; set; }
        public double ProfitMargin { get; set; }
        public int TotalTransactions { get; set; }
        public int TotalUnitsSold { get; set; }
    }

    public class ProductProfitability
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? Category { get; set; }
        public int UnitsSold { get; set; }
        public double Revenue { get; set; }
        public double Cost { get; set; }
        public double Profit { get; set; }
        public double ProfitMargin { get; set; }
    }

    public class SalesTrend
    {
        public DateTime Date { get; set; }
        public double Sales { get; set; }
        public double Profit { get; set; }
        public int TransactionCount { get; set; }
    }

    public interface IAnalyticsService
    {
        Task<DashboardSummary> GetDashboardSummaryAsync(int businessId);
        Task<ProfitAnalytics> GetProfitAnalyticsAsync(int businessId, DateTime startDate, DateTime endDate);
        Task<IEnumerable<ProductProfitability>> GetTopProfitableProductsAsync(int businessId, DateTime startDate, DateTime endDate, int count = 5);
        Task<IEnumerable<SalesTrend>> GetSalesTrendsAsync(int businessId, DateTime startDate, DateTime endDate);
        Task<double> GetTotalInventoryValueAsync(int businessId);
    }
}
