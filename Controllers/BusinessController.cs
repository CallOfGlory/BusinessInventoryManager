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

        public BusinessController(IBusinessService businessService, IClaimsService claimsService)
        {
            _businessService = businessService;
            _claimsService = claimsService;
        }

        // GET: Business
        public async Task<IActionResult> Index()
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var businesses = await _businessService.GetUserBusinessesAsync(userId);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            var viewModels = businesses.Select(b => new BusinessViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                Currency = b.Currency,
                Address = b.Address,
                Phone = b.Phone,
                CreatedAt = b.CreatedAt,
                IsActive = activeBusiness?.Id == b.Id,
                ProductCount = b.Products?.Count ?? 0,
                TransactionCount = b.Transactions?.Count ?? 0
            }).ToList();

            ViewBag.ActiveBusinessId = activeBusiness?.Id;
            return View(viewModels);
        }

        // GET: Business/Create
        public IActionResult Create()
        {
            return View(new BusinessViewModel());
        }

        // POST: Business/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusinessViewModel model)
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
                    Name = model.Name,
                    Description = model.Description,
                    Currency = model.Currency,
                    Address = model.Address,
                    Phone = model.Phone
                };

                await _businessService.CreateBusinessAsync(business, userId);
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
            try
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
                    Address = business.Address,
                    Phone = business.Phone,
                    CreatedAt = business.CreatedAt
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error loading business: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
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
                    Name = model.Name,
                    Description = model.Description,
                    Currency = model.Currency,
                    Address = model.Address,
                    Phone = model.Phone
                };

                await _businessService.UpdateBusinessAsync(business, userId);
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
                await _businessService.SetActiveBusinessAsync(id, userId);
                TempData["SuccessMessage"] = "Active business changed!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error changing active business: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
