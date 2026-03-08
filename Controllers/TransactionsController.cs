using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using WebApplication2.Models;
using WebApplication2.Services.Interface;
using WebApplication2.ViewModels.Transactions;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IBusinessService _businessService;
        private readonly IProductService _productService;
        private readonly IClaimsService _claimsService;

        public TransactionsController(
            ITransactionService transactionService,
            IBusinessService businessService,
            IProductService productService,
            IClaimsService claimsService)
        {
            _transactionService = transactionService;
            _businessService = businessService;
            _productService = productService;
            _claimsService = claimsService;
        }

        // GET: Transactions
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, TransactionType? type)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                TempData["ErrorMessage"] = "Please create a business first.";
                return RedirectToAction("Create", "Business");
            }

            // Default to last 30 days
            startDate ??= DateTime.Today.AddDays(-30);
            endDate ??= DateTime.Today.AddDays(1);

            var transactions = await _transactionService.GetTransactionsAsync(activeBusiness.Id, startDate, endDate, type);
            var summary = await _transactionService.GetTransactionSummaryAsync(activeBusiness.Id, startDate, endDate);

            var viewModel = new TransactionListViewModel
            {
                Transactions = transactions.Select(t => new TransactionViewModel
                {
                    Id = t.Id,
                    ProductId = t.ProductId,
                    ProductName = t.Product?.Name ?? "Unknown",
                    Type = t.Type,
                    Quantity = t.Quantity,
                    UnitPrice = t.UnitPrice,
                    TotalAmount = t.TotalAmount,
                    Notes = t.Notes,
                    TransactionDate = t.TransactionDate,
                    CreatedAt = t.CreatedAt
                }).ToList(),
                StartDate = startDate,
                EndDate = endDate,
                FilterType = type,
                TotalSales = summary.totalSales,
                TotalPurchases = summary.totalPurchases,
                NetProfit = summary.netProfit,
                TotalTransactions = transactions.Count
            };

            ViewBag.BusinessName = activeBusiness.Name;
            return View(viewModel);
        }

        // GET: Transactions/Create
        public async Task<IActionResult> Create(TransactionType? type)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                TempData["ErrorMessage"] = "Please create a business first.";
                return RedirectToAction("Create", "Business");
            }

            var products = await _productService.GetBusinessProductsAsync(activeBusiness.Id);
            ViewBag.Products = new SelectList(products, "Id", "Name");
            ViewBag.TransactionTypes = Enum.GetValues(typeof(TransactionType))
                .Cast<TransactionType>()
                .Select(t => new SelectListItem
                {
                    Value = ((int)t).ToString(),
                    Text = t.ToString(),
                    Selected = type.HasValue && t == type.Value
                });

            var model = new TransactionViewModel
            {
                TransactionDate = DateTime.Now,
                Type = type ?? TransactionType.Sale
            };

            return View(model);
        }

        // POST: Transactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TransactionViewModel model)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                TempData["ErrorMessage"] = "Please create a business first.";
                return RedirectToAction("Create", "Business");
            }

            if (!ModelState.IsValid)
            {
                var products = await _productService.GetBusinessProductsAsync(activeBusiness.Id);
                ViewBag.Products = new SelectList(products, "Id", "Name");
                ViewBag.TransactionTypes = Enum.GetValues(typeof(TransactionType))
                    .Cast<TransactionType>()
                    .Select(t => new SelectListItem
                    {
                        Value = ((int)t).ToString(),
                        Text = t.ToString()
                    });
                return View(model);
            }

            try
            {
                var transaction = new TransactionModel
                {
                    ProductId = model.ProductId,
                    Type = model.Type,
                    Quantity = model.Quantity,
                    UnitPrice = model.UnitPrice,
                    Notes = model.Notes,
                    TransactionDate = model.TransactionDate
                };

                await _transactionService.CreateTransactionAsync(transaction, activeBusiness.Id);
                TempData["SuccessMessage"] = "Transaction recorded successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error recording transaction: {ex.Message}");
                var products = await _productService.GetBusinessProductsAsync(activeBusiness.Id);
                ViewBag.Products = new SelectList(products, "Id", "Name");
                ViewBag.TransactionTypes = Enum.GetValues(typeof(TransactionType))
                    .Cast<TransactionType>()
                    .Select(t => new SelectListItem
                    {
                        Value = ((int)t).ToString(),
                        Text = t.ToString()
                    });
                return View(model);
            }
        }

        // GET: Transactions/Edit/5
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

                var transaction = await _transactionService.GetTransactionByIdAsync(id, activeBusiness.Id);
                if (transaction == null)
                {
                    return NotFound();
                }

                var viewModel = new TransactionViewModel
                {
                    Id = transaction.Id,
                    ProductId = transaction.ProductId,
                    ProductName = transaction.Product?.Name ?? "",
                    Type = transaction.Type,
                    Quantity = transaction.Quantity,
                    UnitPrice = transaction.UnitPrice,
                    TotalAmount = transaction.TotalAmount,
                    Notes = transaction.Notes,
                    TransactionDate = transaction.TransactionDate
                };

                var products = await _productService.GetBusinessProductsAsync(activeBusiness.Id);
                ViewBag.Products = new SelectList(products, "Id", "Name", transaction.ProductId);
                ViewBag.TransactionTypes = Enum.GetValues(typeof(TransactionType))
                    .Cast<TransactionType>()
                    .Select(t => new SelectListItem
                    {
                        Value = ((int)t).ToString(),
                        Text = t.ToString(),
                        Selected = t == transaction.Type
                    });

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error loading transaction: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Transactions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TransactionViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var products = await _productService.GetBusinessProductsAsync(activeBusiness.Id);
                ViewBag.Products = new SelectList(products, "Id", "Name");
                ViewBag.TransactionTypes = Enum.GetValues(typeof(TransactionType))
                    .Cast<TransactionType>()
                    .Select(t => new SelectListItem
                    {
                        Value = ((int)t).ToString(),
                        Text = t.ToString()
                    });
                return View(model);
            }

            try
            {
                var transaction = new TransactionModel
                {
                    Id = id,
                    ProductId = model.ProductId,
                    Type = model.Type,
                    Quantity = model.Quantity,
                    UnitPrice = model.UnitPrice,
                    Notes = model.Notes,
                    TransactionDate = model.TransactionDate
                };

                await _transactionService.UpdateTransactionAsync(transaction, activeBusiness.Id);
                TempData["SuccessMessage"] = "Transaction updated successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error updating transaction: {ex.Message}");
                var products = await _productService.GetBusinessProductsAsync(activeBusiness.Id);
                ViewBag.Products = new SelectList(products, "Id", "Name");
                ViewBag.TransactionTypes = Enum.GetValues(typeof(TransactionType))
                    .Cast<TransactionType>()
                    .Select(t => new SelectListItem
                    {
                        Value = ((int)t).ToString(),
                        Text = t.ToString()
                    });
                return View(model);
            }
        }

        // POST: Transactions/Delete/5
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

                await _transactionService.DeleteTransactionAsync(id, activeBusiness.Id);
                TempData["SuccessMessage"] = "Transaction deleted successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting transaction: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Transactions/QuickSale
        public async Task<IActionResult> QuickSale()
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                TempData["ErrorMessage"] = "Please create a business first.";
                return RedirectToAction("Create", "Business");
            }

            var products = await _productService.GetBusinessProductsAsync(activeBusiness.Id);
            ViewBag.Products = products.Select(p => new
            {
                p.Id,
                p.Name,
                p.SalePrice,
                p.Quantity
            });

            return View();
        }

        // POST: Transactions/QuickSale
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuickSale(int productId, int quantity)
        {
            try
            {
                int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
                var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

                if (activeBusiness == null)
                {
                    return Json(new { success = false, message = "No active business" });
                }

                var product = await _productService.GetProductByIdAsync(productId, activeBusiness.Id);
                if (product == null)
                {
                    return Json(new { success = false, message = "Product not found" });
                }

                var transaction = new TransactionModel
                {
                    ProductId = productId,
                    Type = TransactionType.Sale,
                    Quantity = quantity,
                    UnitPrice = product.SalePrice,
                    TransactionDate = DateTime.Now,
                    Notes = "Quick sale"
                };

                await _transactionService.CreateTransactionAsync(transaction, activeBusiness.Id);
                return Json(new { success = true, message = "Sale recorded!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
