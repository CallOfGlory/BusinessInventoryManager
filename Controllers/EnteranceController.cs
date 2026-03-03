using Microsoft.AspNetCore.Mvc;
using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Models.Enterance;
using WebApplication2.Services.Interface;
using WebApplication2.ViewModels.Enterance;

namespace WebApplication2.Controllers;

public class EnteranceController : Controller
{
    private readonly IEntranceRepository _entranceService;
    private readonly IClaimsService _claimsService;
    public EnteranceController(IEntranceRepository entranceService, IClaimsService claimsService)
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

        LoginModel loginModel = new LoginModel
        {
            Email = model.Email,
            Password = model.Password
        };

        try
        {
            UserModel userRecived = await _entranceService.Login(loginModel);
            await _claimsService.AddClaimsAsync(userRecived.Id, userRecived.Email, HttpContext);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        RegisterModel registerModel = new RegisterModel
        {
            Username = model.Username,
            Email = model.Email,
            Password = model.Password
        };
        try
        {
            UserModel userRecived = await _entranceService.Register(registerModel);
            await _claimsService.AddClaimsAsync(userRecived.Id, userRecived.Email, HttpContext);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }
}