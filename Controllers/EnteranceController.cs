using Microsoft.AspNetCore.Mvc;
using WebApplication2.ViewModels.Enterance;

namespace WebApplication2.Controllers;

public class EnteranceController : Controller
{
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
    public IActionResult Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        return RedirectToAction("Index", "Home");
    }
    
    [HttpPost]
    public IActionResult Register(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        return RedirectToAction("Index", "Home");
    }
}