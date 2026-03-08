namespace WebApplication2.ViewModels.Analytics
{
    public class AnalyticsViewModel
    {
        public string BusinessName { get; set; } = string.Empty;
        public string CurrencySymbol { get; set; } = "$";
        
        // Date Range
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Profit Analytics
        public double TotalRevenue { get; set; }
        public double TotalCost { get; set; }
        public double GrossProfit { get; set; }
        public double ProfitMargin { get; set; }
        public int TotalTransactions { get; set; }
        public int TotalUnitsSold { get; set; }

        // Inventory
        public double TotalInventoryValue { get; set; }
        public int TotalProducts { get; set; }

        // Top Products
        public IEnumerable<TopProductViewModel> TopProducts { get; set; } = new List<TopProductViewModel>();

        // Sales Trends (for chart)
        public IEnumerable<SalesTrendViewModel> SalesTrends { get; set; } = new List<SalesTrendViewModel>();
    }

    public class TopProductViewModel
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

    public class SalesTrendViewModel
    {
        public string Date { get; set; } = string.Empty;
        public double Sales { get; set; }
        public double Profit { get; set; }
        public int TransactionCount { get; set; }
    }
}
