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
        private readonly IClaimsService _claimsService;

        public ProductsController(IProductService productService, IClaimsService claimsService)
        {
            _productService = productService;
            _claimsService = claimsService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var products = await _productService.GetUserProductsAsync(userId);

            // Конвертуємо Model у ViewModel для відображення
            var productViewModels = products.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = (double)p.Price,
                SalePrice = (double)p.SalePrice,
                Quantity = p.Quantity,
                Description = p.Description,
                Category = p.Category,
                CreatedAt = p.CreatedAt,
            }).ToList();

            return View(productViewModels);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
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
                // Конвертуємо ViewModel у Model для збереження в БД
                var product = new ProductModel
                {
                    Name = model.Name,
                    Price = model.Price,
                    SalePrice = model.SalePrice,
                    Quantity = model.Quantity,
                    Description = model.Description,
                    Category = model.Category,
                    UserId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier),
                    CreatedAt = DateTime.Now
                };

                await _productService.CreateProductAsync(product);
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
                var product = await _productService.GetProductByIdAsync(id, userId);

                if (product == null)
                {
                    return NotFound();
                }

                // Конвертуємо Model у ViewModel для редагування
                var viewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = (double)product.Price,
                    SalePrice = (double)product.SalePrice,
                    Quantity = product.Quantity,
                    Description = product.Description,
                    Category = product.Category,
                    CreatedAt = product.CreatedAt,
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

                // Конвертуємо ViewModel у Model для оновлення
                var product = new ProductModel
                {
                    Id = id,
                    Name = model.Name,
                    Price = (double)model.Price,
                    SalePrice = (double)model.SalePrice,
                    Quantity = model.Quantity,
                    Description = model.Description,
                    Category = model.Category,
                    UserId = userId,
                    CreatedAt = model.CreatedAt, // Зберігаємо оригінальну дату створення
                };

                await _productService.UpdateProductAsync(product);
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
                await _productService.DeleteProductAsync(id, userId);

                TempData["SuccessMessage"] = "Product deleted successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting product: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

//https://www.autotrader.co.uk/car-details/202601159154722?sort=relevance&twcs=true&searchId=04b6ef0b-d6ce-4c0c-baad-9a9e7155292d&make=&page=2&postcode=SN14+0PG&price-to=1000&transmission=Manual&year-from=2010&year-to=2026&advertising-location=at_cars&fromsra=&backLinkQueryParams=channel%3Dcars%26make%3D%26postcode%3DSN14%25200PG%26price-to%3D1000%26sort%3Drelevance%26transmission%3DManual%26year-from%3D2010%26year-to%3D2026%26page%3D3%26flrfc%3D1&calc-deposit=100&calc-term=48&calc-mileage=10000