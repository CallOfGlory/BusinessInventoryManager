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

        public BusinessController(
            IBusinessService businessService, 
            IClaimsService claimsService,
            IAnalyticsService analyticsService)
        {
            _businessService = businessService;
            _claimsService = claimsService;
            _analyticsService = analyticsService;
        }

        // GET: Business
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

        // GET: Business/Create
        public IActionResult Create()
        {
            return View(new CreateBusinessViewModel());
        }

        // POST: Business/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Business/Edit/5
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

        // POST: Business/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // POST: Business/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // POST: Business/SetActive/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Business/Details/5
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

            return View(viewModel);
        }
    }
}
