using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication2.Services.Interface;
using WebApplication2.ViewModels.Settings;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly IEnteranceService _userService;
        private readonly IClaimsService _claimsService;

        public SettingsController(IEnteranceService userService, IClaimsService claimsService)
        {
            _userService = userService;
            _claimsService = claimsService;
        }

        public async Task<IActionResult> Index()
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserByIdAsync(userId);
            
            if (user == null) return RedirectToAction("Login", "Enterance");

            var model = new ProfileViewModel
            {
                UserId = user.Id,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                CreatedAt = user.CreatedAt,
                LastLoginAt = user.LastLoginAt
            };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(ProfileViewModel model)
        {
            if (!ModelState.IsValid) return View("Index", model);

            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserByIdAsync(userId);
            
            if (user == null) return RedirectToAction("Login", "Enterance");

            user.Username = model.Username;
            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Phone = model.Phone;

            await _userService.UpdateUserAsync(user);
            TempData["Success"] = "Profile updated successfully!";
            
            return RedirectToAction("Index");
        }

        public IActionResult ChangePassword()
        {
            return View(new ChangePasswordViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);

            try
            {
                await _userService.ChangePasswordAsync(userId, model.CurrentPassword, model.NewPassword);
                TempData["Success"] = "Password changed successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
    }
}
