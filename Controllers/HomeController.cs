using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebApplication2.Models;
using WebApplication2.Services.Interface;
using WebApplication2.ViewModels.Dashboard;

namespace WebApplication2.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IClaimsService _claimsService;
    private readonly IBusinessService _businessService;
    private readonly IAnalyticsService _analyticsService;
    private readonly IEnteranceService _enteranceService;

    public HomeController(
        ILogger<HomeController> logger, 
        IClaimsService claimsService,
        IBusinessService businessService,
        IAnalyticsService analyticsService,
        IEnteranceService enteranceService)
    {
        _logger = logger;
        _claimsService = claimsService;
        _businessService = businessService;
        _analyticsService = analyticsService;
        _enteranceService = enteranceService;
    }

    public async Task<IActionResult> Index()
    {
        int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
        var user = await _enteranceService.GetUserByIdAsync(userId);
        var businesses = await _businessService.GetUserBusinessesAsync(userId);
        var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

        var viewModel = new DashboardViewModel
        {
            Username = user?.Username ?? "User",
            TotalBusinesses = businesses.Count(),
            HasActiveBusiness = activeBusiness != null
        };

        if (activeBusiness != null)
        {
            var summary = await _analyticsService.GetDashboardSummaryAsync(activeBusiness.Id);
            
            viewModel.ActiveBusinessId = activeBusiness.Id;
            viewModel.ActiveBusinessName = activeBusiness.Name;
            viewModel.CurrencySymbol = activeBusiness.CurrencySymbol;
            viewModel.TotalProducts = summary.TotalProducts;
            viewModel.LowStockProducts = summary.LowStockProducts;
            viewModel.TotalInventoryValue = summary.TotalInventoryValue;
            viewModel.TotalSalesToday = summary.TotalSalesToday;
            viewModel.TotalSalesThisMonth = summary.TotalSalesThisMonth;
            viewModel.ProfitThisMonth = summary.ProfitThisMonth;
            viewModel.TransactionsToday = summary.TransactionsToday;
            viewModel.TransactionsThisMonth = summary.TransactionsThisMonth;

            viewModel.RecentTransactions = summary.RecentTransactions.Select(t => new TransactionViewModel
            {
                Id = t.Id,
                ProductName = t.Product?.Name ?? "Unknown",
                Type = t.Type.ToString(),
                Quantity = t.Quantity,
                TotalAmount = t.TotalAmount,
                TransactionDate = t.TransactionDate,
                Notes = t.Notes
            });

            viewModel.LowStockItems = summary.LowStockItems.Select(p => new LowStockProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Quantity = p.Quantity,
                MinStockLevel = p.MinStockLevel
            });
        }

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
