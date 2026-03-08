using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication2.Models;
using WebApplication2.Services.Interface;
using WebApplication2.ViewModels.Profile;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IBusinessService _businessService;
        private readonly IClaimsService _claimsService;

        public ProfileController(
            IProfileService profileService,
            IBusinessService businessService,
            IClaimsService claimsService)
        {
            _profileService = profileService;
            _businessService = businessService;
            _claimsService = claimsService;
        }

        // GET: Profile
        public async Task<IActionResult> Index()
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var user = await _profileService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            var viewModel = new ProfileViewModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                ProfileImage = user.ProfileImage,
                CreatedAt = user.CreatedAt,
                LastLoginAt = user.LastLoginAt,
                TotalBusinesses = user.Businesses?.Count ?? 0,
                ActiveBusinessName = activeBusiness?.Name ?? "No active business"
            };

            return View(viewModel);
        }

        // GET: Profile/Edit
        public async Task<IActionResult> Edit()
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var user = await _profileService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new ProfileViewModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                ProfileImage = user.ProfileImage
            };

            return View(viewModel);
        }

        // POST: Profile/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);

                var user = new UserModel
                {
                    Id = userId,
                    Username = model.Username,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    ProfileImage = model.ProfileImage
                };

                await _profileService.UpdateProfileAsync(user);
                TempData["SuccessMessage"] = "Profile updated successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating profile: {ex.Message}");
                return View(model);
            }
        }

        // GET: Profile/ChangePassword
        public IActionResult ChangePassword()
        {
            return View(new ChangePasswordViewModel());
        }

        // POST: Profile/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);

                var result = await _profileService.ChangePasswordAsync(userId, model.CurrentPassword, model.NewPassword);

                if (result)
                {
                    TempData["SuccessMessage"] = "Password changed successfully!";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("CurrentPassword", "Current password is incorrect.");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error changing password: {ex.Message}");
                return View(model);
            }
        }

        // GET: Profile/Settings
        public async Task<IActionResult> Settings()
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var user = await _profileService.GetUserByIdAsync(userId);
            var businesses = await _businessService.GetUserBusinessesAsync(userId);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            ViewBag.Businesses = businesses;
            ViewBag.ActiveBusinessId = activeBusiness?.Id;

            return View(user);
        }
    }
}
