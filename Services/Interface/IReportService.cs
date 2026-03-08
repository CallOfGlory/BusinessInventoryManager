using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface IReportService
    {
        Task<SalesReportData> GenerateSalesReportAsync(int businessId, DateTime from, DateTime to);
        Task<InventoryReportData> GenerateInventoryReportAsync(int businessId);
        Task<ProfitLossReportData> GenerateProfitLossReportAsync(int businessId, DateTime from, DateTime to);
        Task<byte[]> ExportToCsvAsync<T>(List<T> data, string[] columns);
        Task<byte[]> ExportToPdfAsync(string reportHtml);
    }

    public class SalesReportData
    {
        public decimal TotalSales { get; set; }
        public int TotalTransactions { get; set; }
        public decimal AverageOrderValue { get; set; }
        public List<DailySalesData> DailySales { get; set; } = new();
        public List<ProductSalesData> TopProducts { get; set; } = new();
        public List<CategorySalesData> SalesByCategory { get; set; } = new();
    }

    public class DailySalesData
    {
        public DateTime Date { get; set; }
        public decimal Sales { get; set; }
        public int Orders { get; set; }
    }

    public class ProductSalesData
    {
        public string ProductName { get; set; } = string.Empty;
        public int QuantitySold { get; set; }
        public decimal Revenue { get; set; }
        public decimal Profit { get; set; }
    }

    public class CategorySalesData
    {
        public string Category { get; set; } = string.Empty;
        public decimal Sales { get; set; }
        public double Percentage { get; set; }
    }

    public class InventoryReportData
    {
        public int TotalProducts { get; set; }
        public int TotalUnits { get; set; }
        public decimal TotalValue { get; set; }
        public int LowStockItems { get; set; }
        public int OutOfStockItems { get; set; }
        public List<InventoryItemData> Items { get; set; } = new();
    }

    public class InventoryItemData
    {
        public string ProductName { get; set; } = string.Empty;
        public string? SKU { get; set; }
        public string? Category { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class ProfitLossReportData
    {
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal GrossProfit { get; set; }
        public double ProfitMargin { get; set; }
        public List<MonthlyProfitData> MonthlyData { get; set; } = new();
    }

    public class MonthlyProfitData
    {
        public string Month { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public decimal Cost { get; set; }
        public decimal Profit { get; set; }
    }
}
