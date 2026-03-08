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
            Password = model.Password
        };

        try
        {
            UserModel userRecived = await _entranceService.LoginAsync(user);
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
        Console.WriteLine(model.Username);
        Console.WriteLine(model.Email);
        Console.WriteLine(model.Password);

        if (!ModelState.IsValid)
        {
            return View(model);
        }
        UserModel user = new UserModel
        {
            Username = model.Username,
            Email = model.Email,
            Password = model.Password
        };
        try
        {
            UserModel userRecived = await _entranceService.RegisterAsync(user);
            Console.WriteLine(userRecived.Id);
            Console.WriteLine(userRecived.Email);

            await _claimsService.AddClaimsAsync(userRecived.Id, userRecived.Email, HttpContext);
        }
        catch (Exception e)
        {
            Console.WriteLine("---- ERROR ----");
            Console.WriteLine(e.Message);
            Console.WriteLine(e);
            return View(model);
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}