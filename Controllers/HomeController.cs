using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IClaimsService _claimsService;
    private readonly IAnalyticsService _analyticsService;
    private readonly IBusinessService _businessService;

    public HomeController(
        ILogger<HomeController> logger, 
        IClaimsService claimsService,
        IAnalyticsService analyticsService,
        IBusinessService businessService)
    {
        _logger = logger;
        _claimsService = claimsService;
        _analyticsService = analyticsService;
        _businessService = businessService;
    }

    public async Task<IActionResult> Index()
    {
        int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
        var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

        if (activeBusiness == null)
        {
            return RedirectToAction("Create", "Business");
        }

        var dashboard = await _analyticsService.GetDashboardDataAsync(activeBusiness.Id);
        return View(dashboard);
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
