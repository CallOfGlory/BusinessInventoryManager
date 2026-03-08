using WebApplication2.ViewModels.Analytics;
using WebApplication2.ViewModels.Transactions;

namespace WebApplication2.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        // Current Business Info
        public int BusinessId { get; set; }
        public string BusinessName { get; set; } = string.Empty;
        
        // Quick Stats
        public double TodayRevenue { get; set; }
        public double TodayProfit { get; set; }
        public int TodaySalesCount { get; set; }
        public double MonthRevenue { get; set; }
        public double MonthProfit { get; set; }
        public int MonthSalesCount { get; set; }
        
        // Comparison with previous period
        public double RevenueChangePercent { get; set; }
        public double ProfitChangePercent { get; set; }
        public double SalesChangePercent { get; set; }
        
        // Inventory Alerts
        public int LowStockCount { get; set; }
        public int OutOfStockCount { get; set; }
        public List<TopProductViewModel> LowStockProducts { get; set; } = new();
        
        // Recent Activity
        public List<TransactionViewModel> RecentTransactions { get; set; } = new();
        
        // Top Performers
        public List<TopProductViewModel> TopProducts { get; set; } = new();
        
        // Chart Data
        public List<ChartDataPoint> WeeklyRevenue { get; set; } = new();
        public List<CategorySalesData> CategoryBreakdown { get; set; } = new();
    }
}
