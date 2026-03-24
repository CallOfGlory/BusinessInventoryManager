using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services.Interface;
using WebApplication2.ViewModels.Enterance;

namespace WebApplication2.Controllers;

public class EnteranceController : Controller
{
    private readonly IEnteranceService _entranceService;
    private readonly IClaimsService _claimsService;

    public EnteranceController(IEnteranceService entranceService, IClaimsService claimsService)
    {
        _entranceService = entranceService;
        _claimsService = claimsService;
    }


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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        UserModel user = new UserModel
        {
            Email = model.Email,
            PasswordHash = model.Password
        };

        try
        {
            UserModel userReceived = await _entranceService.LoginAsync(user);
            await _claimsService.AddClaimsAsync(userReceived.Id, userReceived.Email, userReceived.Role.ToString(), HttpContext);
            return RedirectToAction("Index", "Home");
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
            return View(model);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        UserModel user = new UserModel
        {
            Username = model.Username,
            Email = model.Email,
            PasswordHash = model.Password
        };

        try
        {
            UserModel userReceived = await _entranceService.RegisterAsync(user);
            await _claimsService.AddClaimsAsync(userReceived.Id, userReceived.Email, userReceived.Role.ToString(), HttpContext);
            return RedirectToAction("Index", "Home");
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", e.Message);
            return View(model);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
