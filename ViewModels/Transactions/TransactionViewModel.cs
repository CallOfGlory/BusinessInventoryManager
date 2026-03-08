using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication2.ViewModels.Transactions
{
    public class TransactionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product is required")]
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Transaction type is required")]
        public TransactionType Type { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Unit price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be greater than 0")]
        public double UnitPrice { get; set; }

        public double TotalAmount { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string Notes { get; set; } = string.Empty;

        [Required(ErrorMessage = "Transaction date is required")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; }
    }

    public class TransactionListViewModel
    {
        public List<TransactionViewModel> Transactions { get; set; } = new();
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TransactionType? FilterType { get; set; }
        public int? FilterProductId { get; set; }
        
        // Summary statistics
        public double TotalSales { get; set; }
        public double TotalPurchases { get; set; }
        public double NetProfit { get; set; }
        public int TotalTransactions { get; set; }
    }
}
