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
        private readonly IClaimsService _claimsService;

        public AnalyticsController(
            IAnalyticsService analyticsService,
            IBusinessService businessService,
            IClaimsService claimsService)
        {
            _analyticsService = analyticsService;
            _businessService = businessService;
            _claimsService = claimsService;
        }

        // GET: Analytics
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                TempData["ErrorMessage"] = "Please create a business first.";
                return RedirectToAction("Create", "Business");
            }

            // Default to current month
            startDate ??= new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            endDate ??= DateTime.Now.Date.AddDays(1);

            var analytics = await _analyticsService.GetAnalyticsAsync(activeBusiness.Id, startDate.Value, endDate.Value);

            ViewBag.BusinessName = activeBusiness.Name;
            ViewBag.StartDate = startDate.Value.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate.Value.ToString("yyyy-MM-dd");

            return View(analytics);
        }

        // GET: Analytics/Dashboard
        public async Task<IActionResult> Dashboard()
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                TempData["ErrorMessage"] = "Please create a business first.";
                return RedirectToAction("Create", "Business");
            }

            var dashboard = await _analyticsService.GetDashboardDataAsync(activeBusiness.Id);
            return View(dashboard);
        }

        // GET: Analytics/Report
        public async Task<IActionResult> Report(string period = "month")
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                TempData["ErrorMessage"] = "Please create a business first.";
                return RedirectToAction("Create", "Business");
            }

            DateTime startDate;
            DateTime endDate = DateTime.Now.Date.AddDays(1);

            switch (period.ToLower())
            {
                case "week":
                    startDate = DateTime.Now.Date.AddDays(-7);
                    break;
                case "month":
                    startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    break;
                case "quarter":
                    startDate = DateTime.Now.Date.AddMonths(-3);
                    break;
                case "year":
                    startDate = new DateTime(DateTime.Now.Year, 1, 1);
                    break;
                default:
                    startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    break;
            }

            var analytics = await _analyticsService.GetAnalyticsAsync(activeBusiness.Id, startDate, endDate);

            ViewBag.Period = period;
            ViewBag.BusinessName = activeBusiness.Name;

            return View(analytics);
        }

        // API endpoint for chart data
        [HttpGet]
        public async Task<IActionResult> GetChartData(DateTime startDate, DateTime endDate)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                return Json(new { error = "No active business" });
            }

            var revenueData = await _analyticsService.GetRevenueByDayAsync(activeBusiness.Id, startDate, endDate);
            var categoryData = await _analyticsService.GetSalesByCategoryAsync(activeBusiness.Id, startDate, endDate);

            return Json(new
            {
                revenue = revenueData,
                categories = categoryData
            });
        }
    }
}
