namespace WebApplication2.ViewModels.Analytics
{
    public class AnalyticsViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        // Revenue & Profit
        public double TotalRevenue { get; set; }
        public double TotalCost { get; set; }
        public double GrossProfit { get; set; }
        public double ProfitMargin { get; set; }
        
        // Transactions
        public int TotalSalesCount { get; set; }
        public int TotalPurchasesCount { get; set; }
        public int TotalReturnsCount { get; set; }
        
        // Inventory
        public int TotalProducts { get; set; }
        public int LowStockProducts { get; set; }
        public int OutOfStockProducts { get; set; }
        public double InventoryValue { get; set; }
        
        // Top Products
        public List<TopProductViewModel> TopSellingProducts { get; set; } = new();
        public List<TopProductViewModel> MostProfitableProducts { get; set; } = new();
        public List<TopProductViewModel> LowStockProductsList { get; set; } = new();
        
        // Charts Data
        public List<ChartDataPoint> RevenueByDay { get; set; } = new();
        public List<ChartDataPoint> ProfitByDay { get; set; } = new();
        public List<CategorySalesData> SalesByCategory { get; set; } = new();
    }

    public class TopProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int QuantitySold { get; set; }
        public double Revenue { get; set; }
        public double Profit { get; set; }
        public int CurrentStock { get; set; }
        public int MinStockLevel { get; set; }
    }

    public class ChartDataPoint
    {
        public string Label { get; set; } = string.Empty;
        public double Value { get; set; }
    }

    public class CategorySalesData
    {
        public string Category { get; set; } = string.Empty;
        public double TotalSales { get; set; }
        public int TransactionCount { get; set; }
        public double Percentage { get; set; }
    }
}
