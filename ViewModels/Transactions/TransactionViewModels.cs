using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Models;

namespace WebApplication2.ViewModels.Transactions
{
    public class TransactionListViewModel
    {
        public IEnumerable<TransactionItemViewModel> Transactions { get; set; } = new List<TransactionItemViewModel>();
        public string CurrencySymbol { get; set; } = "$";
        public string BusinessName { get; set; } = string.Empty;
        public DateTime? FilterStartDate { get; set; }
        public DateTime? FilterEndDate { get; set; }
        public string? FilterType { get; set; }
        
        // Summary
        public int TotalTransactions { get; set; }
        public double TotalSales { get; set; }
        public double TotalPurchases { get; set; }
    }

    public class TransactionItemViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public TransactionType Type { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }
        public string? Notes { get; set; }
        public DateTime TransactionDate { get; set; }
    }

    public class CreateTransactionViewModel
    {
        [Required(ErrorMessage = "Please select a product")]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Transaction type is required")]
        [Display(Name = "Transaction Type")]
        public TransactionType Type { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Unit price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        [Display(Name = "Notes (Optional)")]
        public string? Notes { get; set; }

        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        // For dropdown
        public IEnumerable<SelectListItem> Products { get; set; } = new List<SelectListItem>();
        public string CurrencySymbol { get; set; } = "$";
        
        // Product details for JS
        public double? ProductPurchasePrice { get; set; }
        public double? ProductSalePrice { get; set; }
        public int? ProductCurrentStock { get; set; }
    }

    public class TransactionDetailsViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }
        public string? Notes { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CurrencySymbol { get; set; } = "$";
    }
}
