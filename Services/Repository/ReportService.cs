using Microsoft.EntityFrameworkCore;
using System.Text;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class ReportService : IReportService
    {
        private readonly ApplicationContext _context;

        public ReportService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<SalesReportData> GenerateSalesReportAsync(int businessId, DateTime from, DateTime to)
        {
            var transactions = await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId && 
                           t.Type == TransactionType.Sale &&
                           t.TransactionDate >= from && t.TransactionDate <= to)
                .ToListAsync();

            var dailySales = transactions
                .GroupBy(t => t.TransactionDate.Date)
                .Select(g => new DailySalesData
                {
                    Date = g.Key,
                    Sales = (decimal)g.Sum(t => t.TotalAmount),
                    Orders = g.Count()
                })
                .OrderBy(d => d.Date)
                .ToList();

            var topProducts = transactions
                .GroupBy(t => t.Product?.Name ?? "Unknown")
                .Select(g => new ProductSalesData
                {
                    ProductName = g.Key,
                    QuantitySold = g.Sum(t => t.Quantity),
                    Revenue = (decimal)g.Sum(t => t.TotalAmount),
                    Profit = (decimal)g.Sum(t => t.ProfitAmount)
                })
                .OrderByDescending(p => p.Revenue)
                .Take(10)
                .ToList();

            return new SalesReportData
            {
                TotalSales = (decimal)transactions.Sum(t => t.TotalAmount),
                TotalTransactions = transactions.Count,
                AverageOrderValue = transactions.Any() ? (decimal)transactions.Average(t => t.TotalAmount) : 0,
                DailySales = dailySales,
                TopProducts = topProducts
            };
        }

        public async Task<InventoryReportData> GenerateInventoryReportAsync(int businessId)
        {
            var products = await _context.Products
                .Where(p => p.BusinessId == businessId && p.IsActive)
                .ToListAsync();

            var items = products.Select(p => new InventoryItemData
            {
                ProductName = p.Name,
                SKU = p.SKU,
                Category = p.Category,
                Quantity = p.Quantity,
                Value = (decimal)(p.PurchasePrice * p.Quantity),
                Status = p.Quantity == 0 ? "Out of Stock" : p.IsLowStock ? "Low Stock" : "In Stock"
            }).ToList();

            return new InventoryReportData
            {
                TotalProducts = products.Count,
                TotalUnits = products.Sum(p => p.Quantity),
                TotalValue = (decimal)products.Sum(p => p.PurchasePrice * p.Quantity),
                LowStockItems = products.Count(p => p.IsLowStock && p.Quantity > 0),
                OutOfStockItems = products.Count(p => p.Quantity == 0),
                Items = items
            };
        }

        public async Task<ProfitLossReportData> GenerateProfitLossReportAsync(int businessId, DateTime from, DateTime to)
        {
            var transactions = await _context.Transactions
                .Where(t => t.BusinessId == businessId && t.TransactionDate >= from && t.TransactionDate <= to)
                .ToListAsync();

            var sales = transactions.Where(t => t.Type == TransactionType.Sale);
            var purchases = transactions.Where(t => t.Type == TransactionType.Purchase);

            var totalRevenue = (decimal)sales.Sum(t => t.TotalAmount);
            var totalCost = (decimal)purchases.Sum(t => t.TotalAmount);
            var grossProfit = totalRevenue - totalCost;

            var monthlyData = transactions
                .GroupBy(t => new { t.TransactionDate.Year, t.TransactionDate.Month })
                .Select(g => new MonthlyProfitData
                {
                    Month = $"{g.Key.Year}-{g.Key.Month:D2}",
                    Revenue = (decimal)g.Where(t => t.Type == TransactionType.Sale).Sum(t => t.TotalAmount),
                    Cost = (decimal)g.Where(t => t.Type == TransactionType.Purchase).Sum(t => t.TotalAmount),
                    Profit = (decimal)(g.Where(t => t.Type == TransactionType.Sale).Sum(t => t.TotalAmount) -
                             g.Where(t => t.Type == TransactionType.Purchase).Sum(t => t.TotalAmount))
                })
                .OrderBy(m => m.Month)
                .ToList();

            return new ProfitLossReportData
            {
                TotalRevenue = totalRevenue,
                TotalCost = totalCost,
                GrossProfit = grossProfit,
                ProfitMargin = totalRevenue > 0 ? (double)(grossProfit / totalRevenue * 100) : 0,
                MonthlyData = monthlyData
            };
        }

        public Task<byte[]> ExportToCsvAsync<T>(List<T> data, string[] columns)
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Join(",", columns));

            foreach (var item in data)
            {
                var values = columns.Select(c => 
                    item?.GetType().GetProperty(c)?.GetValue(item)?.ToString() ?? "");
                sb.AppendLine(string.Join(",", values.Select(v => $"\"{v}\"")));
            }

            return Task.FromResult(Encoding.UTF8.GetBytes(sb.ToString()));
        }

        public Task<byte[]> ExportToPdfAsync(string reportHtml)
        {
            // PDF generation would require a library like iTextSharp or similar
            // For now, return HTML as bytes
            return Task.FromResult(Encoding.UTF8.GetBytes(reportHtml));
        }
    }
}
