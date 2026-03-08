using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly ApplicationContext _context;

        public AnalyticsService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<DashboardSummary> GetDashboardSummaryAsync(int businessId)
        {
            var today = DateTime.UtcNow.Date;
            var monthStart = new DateTime(today.Year, today.Month, 1);
            var monthEnd = monthStart.AddMonths(1).AddDays(-1);

            var products = await _context.Products
                .Where(p => p.BusinessId == businessId && p.IsActive)
                .ToListAsync();

            var todayTransactions = await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId && t.TransactionDate.Date == today)
                .ToListAsync();

            var monthTransactions = await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId && 
                           t.TransactionDate >= monthStart && 
                           t.TransactionDate <= monthEnd)
                .ToListAsync();

            var recentTransactions = await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId)
                .OrderByDescending(t => t.TransactionDate)
                .Take(5)
                .ToListAsync();

            var lowStockThreshold = 10;
            var lowStockItems = products
                .Where(p => p.Quantity <= (p.MinStockLevel ?? lowStockThreshold))
                .OrderBy(p => p.Quantity)
                .Take(5)
                .ToList();

            // Calculate totals
            var salesToday = todayTransactions
                .Where(t => t.Type == TransactionType.Sale)
                .Sum(t => t.TotalAmount);

            var salesThisMonth = monthTransactions
                .Where(t => t.Type == TransactionType.Sale)
                .Sum(t => t.TotalAmount);

            // Calculate profit
            var profitThisMonth = monthTransactions
                .Where(t => t.Type == TransactionType.Sale && t.Product != null)
                .Sum(t => (t.UnitPrice - t.Product!.PurchasePrice) * t.Quantity);

            return new DashboardSummary
            {
                TotalProducts = products.Count,
                LowStockProducts = products.Count(p => p.Quantity <= (p.MinStockLevel ?? lowStockThreshold)),
                TotalInventoryValue = products.Sum(p => p.PurchasePrice * p.Quantity),
                TotalSalesToday = salesToday,
                TotalSalesThisMonth = salesThisMonth,
                ProfitThisMonth = profitThisMonth,
                TransactionsToday = todayTransactions.Count,
                TransactionsThisMonth = monthTransactions.Count,
                RecentTransactions = recentTransactions,
                LowStockItems = lowStockItems
            };
        }

        public async Task<ProfitAnalytics> GetProfitAnalyticsAsync(int businessId, DateTime startDate, DateTime endDate)
        {
            var transactions = await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId && 
                           t.TransactionDate >= startDate && 
                           t.TransactionDate <= endDate &&
                           t.Type == TransactionType.Sale)
                .ToListAsync();

            var totalRevenue = transactions.Sum(t => t.TotalAmount);
            var totalCost = transactions
                .Where(t => t.Product != null)
                .Sum(t => t.Product!.PurchasePrice * t.Quantity);
            var grossProfit = totalRevenue - totalCost;

            return new ProfitAnalytics
            {
                StartDate = startDate,
                EndDate = endDate,
                TotalRevenue = totalRevenue,
                TotalCost = totalCost,
                GrossProfit = grossProfit,
                ProfitMargin = totalRevenue > 0 ? (grossProfit / totalRevenue) * 100 : 0,
                TotalTransactions = transactions.Count,
                TotalUnitsSold = transactions.Sum(t => t.Quantity)
            };
        }

        public async Task<IEnumerable<ProductProfitability>> GetTopProfitableProductsAsync(int businessId, DateTime startDate, DateTime endDate, int count = 5)
        {
            var transactions = await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId && 
                           t.TransactionDate >= startDate && 
                           t.TransactionDate <= endDate &&
                           t.Type == TransactionType.Sale &&
                           t.Product != null)
                .ToListAsync();

            var productProfitability = transactions
                .GroupBy(t => t.ProductId)
                .Select(g => {
                    var product = g.First().Product!;
                    var revenue = g.Sum(t => t.TotalAmount);
                    var cost = g.Sum(t => product.PurchasePrice * t.Quantity);
                    var profit = revenue - cost;
                    
                    return new ProductProfitability
                    {
                        ProductId = g.Key,
                        ProductName = product.Name,
                        Category = product.Category,
                        UnitsSold = g.Sum(t => t.Quantity),
                        Revenue = revenue,
                        Cost = cost,
                        Profit = profit,
                        ProfitMargin = revenue > 0 ? (profit / revenue) * 100 : 0
                    };
                })
                .OrderByDescending(p => p.Profit)
                .Take(count)
                .ToList();

            return productProfitability;
        }

        public async Task<IEnumerable<SalesTrend>> GetSalesTrendsAsync(int businessId, DateTime startDate, DateTime endDate)
        {
            var transactions = await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId && 
                           t.TransactionDate >= startDate && 
                           t.TransactionDate <= endDate &&
                           t.Type == TransactionType.Sale)
                .ToListAsync();

            var trends = transactions
                .GroupBy(t => t.TransactionDate.Date)
                .Select(g => new SalesTrend
                {
                    Date = g.Key,
                    Sales = g.Sum(t => t.TotalAmount),
                    Profit = g.Where(t => t.Product != null)
                             .Sum(t => (t.UnitPrice - t.Product!.PurchasePrice) * t.Quantity),
                    TransactionCount = g.Count()
                })
                .OrderBy(t => t.Date)
                .ToList();

            return trends;
        }

        public async Task<double> GetTotalInventoryValueAsync(int businessId)
        {
            return await _context.Products
                .Where(p => p.BusinessId == businessId && p.IsActive)
                .SumAsync(p => p.PurchasePrice * p.Quantity);
        }
    }
}
