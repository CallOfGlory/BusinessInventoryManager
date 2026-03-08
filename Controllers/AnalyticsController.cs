using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication2.Services.Interface;
using WebApplication2.ViewModels.Analytics;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class AnalyticsController : Controller
    {
        private readonly IAnalyticsService _analyticsService;
        private readonly IBusinessService _businessService;
        private readonly IProductService _productService;
        private readonly IClaimsService _claimsService;

        public AnalyticsController(
            IAnalyticsService analyticsService,
            IBusinessService businessService,
            IProductService productService,
            IClaimsService claimsService)
        {
            _analyticsService = analyticsService;
            _businessService = businessService;
            _productService = productService;
            _claimsService = claimsService;
        }

        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                TempData["ErrorMessage"] = "Please select an active business first.";
                return RedirectToAction("Index", "Business");
            }

            // Default to current month if no dates specified
            var now = DateTime.UtcNow;
            var start = startDate ?? new DateTime(now.Year, now.Month, 1);
            var end = endDate ?? start.AddMonths(1).AddDays(-1);

            var profitAnalytics = await _analyticsService.GetProfitAnalyticsAsync(activeBusiness.Id, start, end);
            var topProducts = await _analyticsService.GetTopProfitableProductsAsync(activeBusiness.Id, start, end, 5);
            var salesTrends = await _analyticsService.GetSalesTrendsAsync(activeBusiness.Id, start, end);
            var inventoryValue = await _analyticsService.GetTotalInventoryValueAsync(activeBusiness.Id);
            var products = await _productService.GetBusinessProductsAsync(activeBusiness.Id);

            var viewModel = new AnalyticsViewModel
            {
                BusinessName = activeBusiness.Name,
                CurrencySymbol = activeBusiness.CurrencySymbol,
                StartDate = start,
                EndDate = end,
                TotalRevenue = profitAnalytics.TotalRevenue,
                TotalCost = profitAnalytics.TotalCost,
                GrossProfit = profitAnalytics.GrossProfit,
                ProfitMargin = profitAnalytics.ProfitMargin,
                TotalTransactions = profitAnalytics.TotalTransactions,
                TotalUnitsSold = profitAnalytics.TotalUnitsSold,
                TotalInventoryValue = inventoryValue,
                TotalProducts = products.Count,
                TopProducts = topProducts.Select(p => new TopProductViewModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Category = p.Category,
                    UnitsSold = p.UnitsSold,
                    Revenue = p.Revenue,
                    Cost = p.Cost,
                    Profit = p.Profit,
                    ProfitMargin = p.ProfitMargin
                }),
                SalesTrends = salesTrends.Select(t => new SalesTrendViewModel
                {
                    Date = t.Date.ToString("MMM dd"),
                    Sales = t.Sales,
                    Profit = t.Profit,
                    TransactionCount = t.TransactionCount
                })
            };

            return View(viewModel);
        }

        // API endpoint for chart data
        [HttpGet]
        public async Task<IActionResult> GetSalesTrends(DateTime startDate, DateTime endDate)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                return BadRequest("No active business");
            }

            var trends = await _analyticsService.GetSalesTrendsAsync(activeBusiness.Id, startDate, endDate);
            
            return Json(trends.Select(t => new
            {
                date = t.Date.ToString("yyyy-MM-dd"),
                label = t.Date.ToString("MMM dd"),
                sales = t.Sales,
                profit = t.Profit,
                transactions = t.TransactionCount
            }));
        }
    }
}
