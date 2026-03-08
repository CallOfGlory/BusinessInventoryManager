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

        public async Task<IActionResult> Index()
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);
            
            if (activeBusiness == null)
            {
                TempData["ErrorMessage"] = "Please select an active business first.";
                return RedirectToAction("Index", "Business");
            }

            var products = await _productService.GetBusinessProductsAsync(activeBusiness.Id);
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
                IsLowStock = p.IsLowStock,
                CreatedAt = p.CreatedAt
            }).ToList();

            ViewBag.BusinessName = activeBusiness.Name;
            ViewBag.CurrencySymbol = activeBusiness.CurrencySymbol;
            return View(productViewModels);
        }

        public async Task<IActionResult> Create()
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);
            if (activeBusiness == null) return RedirectToAction("Index", "Business");
            
            return View(new ProductViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);
            if (activeBusiness == null) return RedirectToAction("Index", "Business");

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
                UserId = userId,
                BusinessId = activeBusiness.Id
            };

            await _productService.CreateProductAsync(product);
            TempData["SuccessMessage"] = "Product created successfully!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var product = await _productService.GetProductByIdAsync(id, userId);
            if (product == null) return NotFound();

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
                CreatedAt = product.CreatedAt
            };
            return View(viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel model)
        {
            if (id != model.Id) return NotFound();
            if (!ModelState.IsValid) return View(model);

            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

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
                UserId = userId,
                BusinessId = activeBusiness?.Id
            };

            await _productService.UpdateProductAsync(product);
            TempData["SuccessMessage"] = "Product updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            await _productService.DeleteProductAsync(id, userId);
            TempData["SuccessMessage"] = "Product deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
