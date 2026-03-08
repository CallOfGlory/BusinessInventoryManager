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
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, string? type)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                TempData["ErrorMessage"] = "Please select an active business first.";
                return RedirectToAction("Index", "Business");
            }

            IEnumerable<TransactionModel> transactions;
            
            if (startDate.HasValue && endDate.HasValue)
            {
                transactions = await _transactionService.GetTransactionsByDateRangeAsync(
                    activeBusiness.Id, startDate.Value, endDate.Value.AddDays(1).AddSeconds(-1));
            }
            else
            {
                transactions = await _transactionService.GetBusinessTransactionsAsync(activeBusiness.Id);
            }

            // Filter by type if specified
            if (!string.IsNullOrEmpty(type) && Enum.TryParse<TransactionType>(type, out var transactionType))
            {
                transactions = transactions.Where(t => t.Type == transactionType);
            }

            var viewModel = new TransactionListViewModel
            {
                BusinessName = activeBusiness.Name,
                CurrencySymbol = activeBusiness.CurrencySymbol,
                FilterStartDate = startDate,
                FilterEndDate = endDate,
                FilterType = type,
                Transactions = transactions.Select(t => new TransactionItemViewModel
                {
                    Id = t.Id,
                    ProductName = t.Product?.Name ?? "Unknown",
                    ProductId = t.ProductId,
                    Type = t.Type,
                    Quantity = t.Quantity,
                    UnitPrice = t.UnitPrice,
                    TotalAmount = t.TotalAmount,
                    Notes = t.Notes,
                    TransactionDate = t.TransactionDate
                }),
                TotalTransactions = transactions.Count(),
                TotalSales = transactions.Where(t => t.Type == TransactionType.Sale).Sum(t => t.TotalAmount),
                TotalPurchases = transactions.Where(t => t.Type == TransactionType.Purchase).Sum(t => t.TotalAmount)
            };

            return View(viewModel);
        }

        // GET: Transactions/Create
        public async Task<IActionResult> Create()
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                TempData["ErrorMessage"] = "Please select an active business first.";
                return RedirectToAction("Index", "Business");
            }

            var products = await _productService.GetBusinessProductsAsync(activeBusiness.Id);

            var viewModel = new CreateTransactionViewModel
            {
                CurrencySymbol = activeBusiness.CurrencySymbol,
                TransactionDate = DateTime.Now,
                Products = products.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.Name} (Stock: {p.Quantity})"
                })
            };

            return View(viewModel);
        }

        // POST: Transactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTransactionViewModel model)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                return RedirectToAction("Index", "Business");
            }

            if (!ModelState.IsValid)
            {
                var products = await _productService.GetBusinessProductsAsync(activeBusiness.Id);
                model.Products = products.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.Name} (Stock: {p.Quantity})"
                });
                model.CurrencySymbol = activeBusiness.CurrencySymbol;
                return View(model);
            }

            try
            {
                switch (model.Type)
                {
                    case TransactionType.Purchase:
                        await _transactionService.RecordPurchaseAsync(
                            activeBusiness.Id, model.ProductId, model.Quantity, model.UnitPrice, model.Notes);
                        TempData["SuccessMessage"] = "Purchase recorded successfully! Stock has been increased.";
                        break;
                    case TransactionType.Sale:
                        await _transactionService.RecordSaleAsync(
                            activeBusiness.Id, model.ProductId, model.Quantity, model.UnitPrice, model.Notes);
                        TempData["SuccessMessage"] = "Sale recorded successfully! Stock has been decreased.";
                        break;
                    case TransactionType.Adjustment:
                        await _transactionService.RecordAdjustmentAsync(
                            activeBusiness.Id, model.ProductId, model.Quantity, model.Notes);
                        TempData["SuccessMessage"] = "Stock adjustment recorded successfully!";
                        break;
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                var products = await _productService.GetBusinessProductsAsync(activeBusiness.Id);
                model.Products = products.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = $"{p.Name} (Stock: {p.Quantity})"
                });
                model.CurrencySymbol = activeBusiness.CurrencySymbol;
                return View(model);
            }
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int id)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                return RedirectToAction("Index", "Business");
            }

            var transaction = await _transactionService.GetTransactionByIdAsync(id, activeBusiness.Id);
            if (transaction == null)
            {
                return NotFound();
            }

            var viewModel = new TransactionDetailsViewModel
            {
                Id = transaction.Id,
                ProductName = transaction.Product?.Name ?? "Unknown",
                ProductId = transaction.ProductId,
                TransactionType = transaction.Type.ToString(),
                Quantity = transaction.Quantity,
                UnitPrice = transaction.UnitPrice,
                TotalAmount = transaction.TotalAmount,
                Notes = transaction.Notes,
                TransactionDate = transaction.TransactionDate,
                CreatedAt = transaction.CreatedAt,
                CurrencySymbol = activeBusiness.CurrencySymbol
            };

            return View(viewModel);
        }

        // POST: Transactions/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var activeBusiness = await _businessService.GetActiveBusinessAsync(userId);

            if (activeBusiness == null)
            {
                return RedirectToAction("Index", "Business");
            }

            try
            {
                await _transactionService.DeleteTransactionAsync(id, activeBusiness.Id);
                TempData["SuccessMessage"] = "Transaction deleted successfully.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting transaction: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }

        // API endpoint for getting product details
        [HttpGet]
        public async Task<IActionResult> GetProductDetails(int productId)
        {
            int userId = await _claimsService.GetClaimCertain<int>(HttpContext, ClaimTypes.NameIdentifier);
            var product = await _productService.GetProductByIdAsync(productId, userId);

            if (product == null)
            {
                return NotFound();
            }

            return Json(new
            {
                purchasePrice = product.PurchasePrice,
                salePrice = product.SalePrice,
                currentStock = product.Quantity,
                name = product.Name
            });
        }
    }
}
