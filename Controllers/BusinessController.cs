using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication2.Models;
using WebApplication2.Services.Interface;
using WebApplication2.ViewModels.Business;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class BusinessController : Controller
    {
        private readonly IBusinessService _businessService;
        private readonly IClaimsService _claimsService;
        private readonly IAnalyticsService _analyticsService;
        private readonly IEnteranceService _enteranceService;

        public BusinessController(
            IBusinessService businessService, 
            IClaimsService claimsService,
            IAnalyticsService analyticsService,
            IEnteranceService enteranceService)
        {
            _businessService = businessService;
            _claimsService = claimsService;
            _analyticsService = analyticsService;
            _enteranceService = enteranceService;
        }

        public async Task<IActionResult> Index()
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var businesses = await _businessService.GetUserBusinessesAsync(userId);

            var viewModel = new BusinessListViewModel
            {
                Businesses = businesses.Select(b => new BusinessViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description,
                    Currency = b.Currency,
                    CurrencySymbol = b.CurrencySymbol,
                    IsActive = b.IsActive,
                    CreatedAt = b.CreatedAt,
                    UpdatedAt = b.UpdatedAt,
                    ProductCount = b.Products?.Count ?? 0,
                    TransactionCount = b.Transactions?.Count ?? 0
                }),
                ActiveBusinessId = businesses.FirstOrDefault(b => b.IsActive)?.Id ?? 0
            };

            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View(new CreateBusinessViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateBusinessViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);

                var business = new BusinessModel
                {
                    UserId = userId,
                    Name = model.Name,
                    Description = model.Description ?? string.Empty,
                    Currency = model.Currency,
                    CurrencySymbol = model.CurrencySymbol
                };

                await _businessService.CreateBusinessAsync(business);
                TempData["SuccessMessage"] = "Business created successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating business: {ex.Message}");
                return View(model);
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var business = await _businessService.GetBusinessByIdAsync(id, userId);

            if (business == null)
            {
                return NotFound();
            }

            var viewModel = new BusinessViewModel
            {
                Id = business.Id,
                Name = business.Name,
                Description = business.Description,
                Currency = business.Currency,
                CurrencySymbol = business.CurrencySymbol,
                IsActive = business.IsActive,
                CreatedAt = business.CreatedAt,
                UpdatedAt = business.UpdatedAt
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, BusinessViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);

                var business = new BusinessModel
                {
                    Id = id,
                    UserId = userId,
                    Name = model.Name,
                    Description = model.Description ?? string.Empty,
                    Currency = model.Currency,
                    CurrencySymbol = model.CurrencySymbol
                };

                await _businessService.UpdateBusinessAsync(business);
                TempData["SuccessMessage"] = "Business updated successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating business: {ex.Message}");
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
                await _businessService.DeleteBusinessAsync(id, userId);
                TempData["SuccessMessage"] = "Business deleted successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting business: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetActive(int id)
        {
            try
            {
                int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
                await _businessService.SetActiveBusinessAsync(userId, id);
                TempData["SuccessMessage"] = "Active business changed successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error changing active business: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var business = await _businessService.GetBusinessByIdAsync(id, userId);

            if (business == null)
            {
                return NotFound();
            }

            var inventoryValue = await _analyticsService.GetTotalInventoryValueAsync(id);

            var viewModel = new BusinessViewModel
            {
                Id = business.Id,
                Name = business.Name,
                Description = business.Description,
                Currency = business.Currency,
                CurrencySymbol = business.CurrencySymbol,
                IsActive = business.IsActive,
                CreatedAt = business.CreatedAt,
                UpdatedAt = business.UpdatedAt,
                ProductCount = business.Products?.Count ?? 0,
                TransactionCount = business.Transactions?.Count ?? 0,
                TotalInventoryValue = inventoryValue
            };

            if (User.IsInRole("Admin"))
            {
                var team = await _enteranceService.GetUsersByBusinessIdAsync(business.Id);
                viewModel.TeamMembers = team
                    .Where(u => u.Id != userId)
                    .Select(u => new TeamMemberViewModel
                    {
                        Id = u.Id,
                        Username = u.Username,
                        Email = u.Email,
                        Role = u.Role.ToString()
                    })
                    .ToList();
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveTeamMember(int id, int businessId)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var business = await _businessService.GetBusinessByIdAsync(businessId, userId);
            if (business == null)
            {
                return NotFound();
            }

            var member = await _enteranceService.GetUserByIdAsync(id);
            if (member == null || member.BusinessId != business.Id || member.Role != UserRole.Staff)
            {
                return RedirectToAction("Details", new { id = businessId });
            }

            await _enteranceService.DeleteUserAsync(id);
            TempData["SuccessMessage"] = "Team member removed successfully!";
            return RedirectToAction("Details", new { id = businessId });
        }
    }
}
