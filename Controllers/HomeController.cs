using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Controllers;


[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IClaimsService _claimsService;

    public HomeController(ILogger<HomeController> logger, IClaimsService claimsService)
    {
        _logger = logger;
        _claimsService = claimsService;
    }

    public async Task<IActionResult> Index()
    {

        var allClaims = await _claimsService.GetClaimsAsync(HttpContext);

        return View();
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