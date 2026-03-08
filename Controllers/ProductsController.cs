using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication2.Models;
using WebApplication2.Services.Interface;
using WebApplication2.ViewModels.Products;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBusinessService _businessService;
        private readonly IClaimsService _claimsService;

        public ProductsController(IProductService productService, IBusinessService businessService, IClaimsService claimsService)
        {
            _productService = productService;
            _businessService = businessService;
            _claimsService = claimsService;
        }

        // GET: Products
        public async Task<IActionResult> Index(string search, string category, bool? lowStock)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                TempData["ErrorMessage"] = "Please create a business first.";
                return RedirectToAction("Create", "Business");
            }

            var products = await _productService.GetBusinessProductsAsync(activeBusiness.Id);

            // Apply filters
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => 
                    p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    p.SKU.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category).ToList();
            }

            if (lowStock == true)
            {
                products = products.Where(p => p.Quantity <= p.MinStockLevel).ToList();
            }

            var productViewModels = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                SKU = p.SKU,
                PurchasePrice = p.PurchasePrice,
                SalePrice = p.SalePrice,
                Quantity = p.Quantity,
                MinStockLevel = p.MinStockLevel,
                Description = p.Description,
                Category = p.Category,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                SupplierName = p.Supplier?.Name ?? ""
            }).ToList();

            ViewBag.Categories = products.Select(p => p.Category).Distinct().Where(c => !string.IsNullOrEmpty(c)).ToList();
            ViewBag.BusinessName = activeBusiness.Name;
            ViewBag.Search = search;
            ViewBag.Category = category;
            ViewBag.LowStock = lowStock;

            return View(productViewModels);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                TempData["ErrorMessage"] = "Please create a business first.";
                return RedirectToAction("Create", "Business");
            }

            return View(new ProductViewModel());
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
                var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

                if (activeBusiness == null)
                {
                    TempData["ErrorMessage"] = "Please create a business first.";
                    return RedirectToAction("Create", "Business");
                }

                var product = new ProductModel
                {
                    Name = model.Name,
                    SKU = model.SKU,
                    PurchasePrice = model.PurchasePrice,
                    SalePrice = model.SalePrice,
                    Quantity = model.Quantity,
                    MinStockLevel = model.MinStockLevel,
                    Description = model.Description,
                    Category = model.Category,
                    SupplierId = model.SupplierId,
                    UserId = userId
                };

                await _productService.CreateProductAsync(product, activeBusiness.Id);
                TempData["SuccessMessage"] = "Product created successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error creating product: {ex.Message}");
                return View(model);
            }
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
                var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

                if (activeBusiness == null)
                {
                    return NotFound();
                }

                var product = await _productService.GetProductByIdAsync(id, activeBusiness.Id);

                if (product == null)
                {
                    return NotFound();
                }

                var viewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    SKU = product.SKU,
                    PurchasePrice = product.PurchasePrice,
                    SalePrice = product.SalePrice,
                    Quantity = product.Quantity,
                    MinStockLevel = product.MinStockLevel,
                    Description = product.Description,
                    Category = product.Category,
                    SupplierId = product.SupplierId,
                    IsActive = product.IsActive,
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error loading product: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel model)
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
                var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

                if (activeBusiness == null)
                {
                    return NotFound();
                }

                var product = new ProductModel
                {
                    Id = id,
                    Name = model.Name,
                    SKU = model.SKU,
                    PurchasePrice = model.PurchasePrice,
                    SalePrice = model.SalePrice,
                    Quantity = model.Quantity,
                    MinStockLevel = model.MinStockLevel,
                    Description = model.Description,
                    Category = model.Category,
                    SupplierId = model.SupplierId
                };

                await _productService.UpdateProductAsync(product, activeBusiness.Id);
                TempData["SuccessMessage"] = "Product updated successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating product: {ex.Message}");
                return View(model);
            }
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
                var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

                if (activeBusiness == null)
                {
                    TempData["ErrorMessage"] = "No active business found.";
                    return RedirectToAction(nameof(Index));
                }

                await _productService.DeleteProductAsync(id, activeBusiness.Id);
                TempData["SuccessMessage"] = "Product deleted successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting product: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
                var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

                if (activeBusiness == null)
                {
                    return NotFound();
                }

                var product = await _productService.GetProductByIdAsync(id, activeBusiness.Id);

                if (product == null)
                {
                    return NotFound();
                }

                var viewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    SKU = product.SKU,
                    PurchasePrice = product.PurchasePrice,
                    SalePrice = product.SalePrice,
                    Quantity = product.Quantity,
                    MinStockLevel = product.MinStockLevel,
                    Description = product.Description,
                    Category = product.Category,
                    IsActive = product.IsActive,
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt,
                    SupplierName = product.Supplier?.Name ?? "Not assigned"
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error loading product: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}

//https://www.autotrader.co.uk/car-details/202601159154722?sort=relevance&twcs=true&searchId=04b6ef0b-d6ce-4c0c-baad-9a9e7155292d&make=&page=2&postcode=SN14+0PG&price-to=1000&transmission=Manual&year-from=2010&year-to=2026&advertising-location=at_cars&fromsra=&backLinkQueryParams=channel%3Dcars%26make%3D%26postcode%3DSN14%25200PG%26price-to%3D1000%26sort%3Drelevance%26transmission%3DManual%26year-from%3D2010%26year-to%3D2026%26page%3D3%26flrfc%3D1&calc-deposit=100&calc-term=48&calc-mileage=10000
