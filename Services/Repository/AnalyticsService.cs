using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services.Interface;
using WebApplication2.ViewModels.Analytics;
using WebApplication2.ViewModels.Dashboard;
using WebApplication2.ViewModels.Transactions;

namespace WebApplication2.Services.Repository
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly ApplicationContext _context;
        private readonly ITransactionService _transactionService;

        public AnalyticsService(ApplicationContext context, ITransactionService transactionService)
        {
            _context = context;
            _transactionService = transactionService;
        }

        public async Task<AnalyticsViewModel> GetAnalyticsAsync(int businessId, DateTime startDate, DateTime endDate)
        {
            var transactions = await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId && t.TransactionDate >= startDate && t.TransactionDate <= endDate)
                .ToListAsync();

            var products = await _context.Products
                .Where(p => p.BusinessId == businessId && p.IsActive)
                .ToListAsync();

            var sales = transactions.Where(t => t.Type == TransactionType.Sale).ToList();
            var purchases = transactions.Where(t => t.Type == TransactionType.Purchase).ToList();
            var returns = transactions.Where(t => t.Type == TransactionType.Return).ToList();

            var totalRevenue = sales.Sum(t => t.TotalAmount);
            var totalCost = purchases.Sum(t => t.TotalAmount);
            var totalReturns = returns.Sum(t => t.TotalAmount);
            var grossProfit = totalRevenue - totalReturns - totalCost;

            return new AnalyticsViewModel
            {
                StartDate = startDate,
                EndDate = endDate,
                TotalRevenue = totalRevenue,
                TotalCost = totalCost,
                GrossProfit = grossProfit,
                ProfitMargin = totalRevenue > 0 ? (grossProfit / totalRevenue) * 100 : 0,
                TotalSalesCount = sales.Count,
                TotalPurchasesCount = purchases.Count,
                TotalReturnsCount = returns.Count,
                TotalProducts = products.Count,
                LowStockProducts = products.Count(p => p.Quantity > 0 && p.Quantity <= p.MinStockLevel),
                OutOfStockProducts = products.Count(p => p.Quantity == 0),
                InventoryValue = products.Sum(p => p.Quantity * p.PurchasePrice),
                TopSellingProducts = await GetTopSellingProductsAsync(businessId, startDate, endDate, 5),
                MostProfitableProducts = await GetMostProfitableProductsAsync(businessId, startDate, endDate, 5),
                LowStockProductsList = await GetLowStockProductsAsync(businessId),
                RevenueByDay = await GetRevenueByDayAsync(businessId, startDate, endDate),
                ProfitByDay = await GetProfitByDayAsync(businessId, startDate, endDate),
                SalesByCategory = await GetSalesByCategoryAsync(businessId, startDate, endDate)
            };
        }

        public async Task<DashboardViewModel> GetDashboardDataAsync(int businessId)
        {
            var business = await _context.Businesses.FindAsync(businessId);
            var today = DateTime.Today;
            var startOfMonth = new DateTime(today.Year, today.Month, 1);
            var startOfLastMonth = startOfMonth.AddMonths(-1);
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek);

            // Today's stats
            var todayTransactions = await _context.Transactions
                .Where(t => t.BusinessId == businessId && t.TransactionDate.Date == today)
                .ToListAsync();

            var todaySales = todayTransactions.Where(t => t.Type == TransactionType.Sale);
            var todayRevenue = todaySales.Sum(t => t.TotalAmount);

            // This month's stats
            var monthTransactions = await _context.Transactions
                .Where(t => t.BusinessId == businessId && t.TransactionDate >= startOfMonth)
                .ToListAsync();

            var monthSales = monthTransactions.Where(t => t.Type == TransactionType.Sale);
            var monthRevenue = monthSales.Sum(t => t.TotalAmount);
            var monthPurchases = monthTransactions.Where(t => t.Type == TransactionType.Purchase).Sum(t => t.TotalAmount);

            // Last month's stats for comparison
            var lastMonthTransactions = await _context.Transactions
                .Where(t => t.BusinessId == businessId && t.TransactionDate >= startOfLastMonth && t.TransactionDate < startOfMonth)
                .ToListAsync();

            var lastMonthRevenue = lastMonthTransactions.Where(t => t.Type == TransactionType.Sale).Sum(t => t.TotalAmount);

            // Low stock products
            var lowStockProducts = await GetLowStockProductsAsync(businessId);

            // Recent transactions
            var recentTransactions = await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId)
                .OrderByDescending(t => t.TransactionDate)
                .Take(5)
                .Select(t => new TransactionViewModel
                {
                    Id = t.Id,
                    ProductId = t.ProductId,
                    ProductName = t.Product.Name,
                    Type = t.Type,
                    Quantity = t.Quantity,
                    UnitPrice = t.UnitPrice,
                    TotalAmount = t.TotalAmount,
                    TransactionDate = t.TransactionDate
                })
                .ToListAsync();

            // Weekly revenue chart
            var weeklyRevenue = new List<ChartDataPoint>();
            for (int i = 6; i >= 0; i--)
            {
                var date = today.AddDays(-i);
                var dayRevenue = await _context.Transactions
                    .Where(t => t.BusinessId == businessId && t.TransactionDate.Date == date && t.Type == TransactionType.Sale)
                    .SumAsync(t => t.TotalAmount);

                weeklyRevenue.Add(new ChartDataPoint
                {
                    Label = date.ToString("ddd"),
                    Value = dayRevenue
                });
            }

            return new DashboardViewModel
            {
                BusinessId = businessId,
                BusinessName = business?.Name ?? "Unknown",
                TodayRevenue = todayRevenue,
                TodayProfit = todayRevenue - todayTransactions.Where(t => t.Type == TransactionType.Purchase).Sum(t => t.TotalAmount),
                TodaySalesCount = todaySales.Count(),
                MonthRevenue = monthRevenue,
                MonthProfit = monthRevenue - monthPurchases,
                MonthSalesCount = monthSales.Count(),
                RevenueChangePercent = lastMonthRevenue > 0 ? ((monthRevenue - lastMonthRevenue) / lastMonthRevenue) * 100 : 0,
                LowStockCount = lowStockProducts.Count(p => p.CurrentStock > 0),
                OutOfStockCount = lowStockProducts.Count(p => p.CurrentStock == 0),
                LowStockProducts = lowStockProducts.Take(5).ToList(),
                RecentTransactions = recentTransactions,
                TopProducts = await GetTopSellingProductsAsync(businessId, startOfMonth, today, 5),
                WeeklyRevenue = weeklyRevenue,
                CategoryBreakdown = await GetSalesByCategoryAsync(businessId, startOfMonth, today)
            };
        }

        public async Task<List<TopProductViewModel>> GetTopSellingProductsAsync(int businessId, DateTime startDate, DateTime endDate, int count = 5)
        {
            var salesByProduct = await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId && t.Type == TransactionType.Sale && t.TransactionDate >= startDate && t.TransactionDate <= endDate)
                .GroupBy(t => new { t.ProductId, t.Product.Name, t.Product.Category, t.Product.Quantity, t.Product.MinStockLevel, t.Product.PurchasePrice })
                .Select(g => new TopProductViewModel
                {
                    ProductId = g.Key.ProductId,
                    ProductName = g.Key.Name,
                    Category = g.Key.Category,
                    QuantitySold = g.Sum(t => t.Quantity),
                    Revenue = g.Sum(t => t.TotalAmount),
                    Profit = g.Sum(t => t.TotalAmount) - (g.Sum(t => t.Quantity) * g.Key.PurchasePrice),
                    CurrentStock = g.Key.Quantity,
                    MinStockLevel = g.Key.MinStockLevel
                })
                .OrderByDescending(p => p.QuantitySold)
                .Take(count)
                .ToListAsync();

            return salesByProduct;
        }

        public async Task<List<TopProductViewModel>> GetMostProfitableProductsAsync(int businessId, DateTime startDate, DateTime endDate, int count = 5)
        {
            var profitByProduct = await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId && t.Type == TransactionType.Sale && t.TransactionDate >= startDate && t.TransactionDate <= endDate)
                .GroupBy(t => new { t.ProductId, t.Product.Name, t.Product.Category, t.Product.Quantity, t.Product.MinStockLevel, t.Product.PurchasePrice })
                .Select(g => new TopProductViewModel
                {
                    ProductId = g.Key.ProductId,
                    ProductName = g.Key.Name,
                    Category = g.Key.Category,
                    QuantitySold = g.Sum(t => t.Quantity),
                    Revenue = g.Sum(t => t.TotalAmount),
                    Profit = g.Sum(t => t.TotalAmount) - (g.Sum(t => t.Quantity) * g.Key.PurchasePrice),
                    CurrentStock = g.Key.Quantity,
                    MinStockLevel = g.Key.MinStockLevel
                })
                .OrderByDescending(p => p.Profit)
                .Take(count)
                .ToListAsync();

            return profitByProduct;
        }

        public async Task<List<TopProductViewModel>> GetLowStockProductsAsync(int businessId)
        {
            return await _context.Products
                .Where(p => p.BusinessId == businessId && p.IsActive && p.Quantity <= p.MinStockLevel)
                .OrderBy(p => p.Quantity)
                .Select(p => new TopProductViewModel
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    Category = p.Category,
                    CurrentStock = p.Quantity,
                    MinStockLevel = p.MinStockLevel
                })
                .ToListAsync();
        }

        public async Task<List<ChartDataPoint>> GetRevenueByDayAsync(int businessId, DateTime startDate, DateTime endDate)
        {
            var dailyRevenue = await _context.Transactions
                .Where(t => t.BusinessId == businessId && t.Type == TransactionType.Sale && t.TransactionDate >= startDate && t.TransactionDate <= endDate)
                .GroupBy(t => t.TransactionDate.Date)
                .Select(g => new ChartDataPoint
                {
                    Label = g.Key.ToString("MMM dd"),
                    Value = g.Sum(t => t.TotalAmount)
                })
                .OrderBy(d => d.Label)
                .ToListAsync();

            return dailyRevenue;
        }

        private async Task<List<ChartDataPoint>> GetProfitByDayAsync(int businessId, DateTime startDate, DateTime endDate)
        {
            var transactions = await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId && t.TransactionDate >= startDate && t.TransactionDate <= endDate)
                .ToListAsync();

            var dailyProfit = transactions
                .GroupBy(t => t.TransactionDate.Date)
                .Select(g => new ChartDataPoint
                {
                    Label = g.Key.ToString("MMM dd"),
                    Value = g.Where(t => t.Type == TransactionType.Sale).Sum(t => t.TotalAmount) -
                            g.Where(t => t.Type == TransactionType.Purchase).Sum(t => t.TotalAmount) -
                            g.Where(t => t.Type == TransactionType.Return).Sum(t => t.TotalAmount)
                })
                .OrderBy(d => d.Label)
                .ToList();

            return dailyProfit;
        }

        public async Task<List<CategorySalesData>> GetSalesByCategoryAsync(int businessId, DateTime startDate, DateTime endDate)
        {
            var salesByCategory = await _context.Transactions
                .Include(t => t.Product)
                .Where(t => t.BusinessId == businessId && t.Type == TransactionType.Sale && t.TransactionDate >= startDate && t.TransactionDate <= endDate)
                .GroupBy(t => t.Product.Category)
                .Select(g => new CategorySalesData
                {
                    Category = string.IsNullOrEmpty(g.Key) ? "Uncategorized" : g.Key,
                    TotalSales = g.Sum(t => t.TotalAmount),
                    TransactionCount = g.Count()
                })
                .OrderByDescending(c => c.TotalSales)
                .ToListAsync();

            var totalSales = salesByCategory.Sum(c => c.TotalSales);
            foreach (var category in salesByCategory)
            {
                category.Percentage = totalSales > 0 ? (category.TotalSales / totalSales) * 100 : 0;
            }

            return salesByCategory;
        }
    }
}
