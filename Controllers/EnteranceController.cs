using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services.Interface;
using WebApplication2.ViewModels.Enterance;

namespace WebApplication2.Controllers;

public class EnteranceController : Controller
{
    private readonly IEnteranceService _entranceService; // Змінено з IEntranceRepository на IEnteranceService
    private readonly IClaimsService _claimsService;

    public EnteranceController(IEnteranceService entranceService, IClaimsService claimsService) // Змінено тип параметра
    {
        _entranceService = entranceService;
        _claimsService = claimsService;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        UserModel user = new UserModel
        {
            Email = model.Email,
            PasswordHash = model.Password // Password will be verified against hash in service
        };

        try
        {
            UserModel userReceived = await _entranceService.LoginAsync(user);
            await _claimsService.AddClaimsAsync(userReceived.Id, userReceived.Email, HttpContext);
            return RedirectToAction("Index", "Home");
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        UserModel user = new UserModel
        {
            Username = model.Username,
            Email = model.Email,
            PasswordHash = model.Password // Will be hashed in the service
        };
        
        try
        {
            UserModel userReceived = await _entranceService.RegisterAsync(user);
            await _claimsService.AddClaimsAsync(userReceived.Id, userReceived.Email, HttpContext);
            TempData["SuccessMessage"] = "Registration successful! Welcome to Business Inventory Manager.";
            return RedirectToAction("Index", "Home");
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
            return View(model);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
