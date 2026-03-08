using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.Products;

public class ProductViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
    public string Name { get; set; } = string.Empty;

    [StringLength(50, ErrorMessage = "SKU cannot exceed 50 characters")]
    public string SKU { get; set; } = string.Empty;

    [Required(ErrorMessage = "Purchase price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Purchase price must be greater than 0")]
    public double PurchasePrice { get; set; }

    [Required(ErrorMessage = "Sale price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Sale price must be greater than 0")]
    public double SalePrice { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative")]
    public int Quantity { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Minimum stock level cannot be negative")]
    public int MinStockLevel { get; set; } = 5;

    [Required(ErrorMessage = "Description is required")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Description must be between 10 and 2000 characters")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Category is required")]
    public string Category { get; set; } = string.Empty;

    public int? SupplierId { get; set; }
    public string SupplierName { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Calculated properties
    public double ProfitPerUnit => SalePrice - PurchasePrice;
    public double TotalProfit => ProfitPerUnit * Quantity;
    public double ProfitMargin => SalePrice > 0 ? (ProfitPerUnit / SalePrice) * 100 : 0;
    public bool IsLowStock => Quantity <= MinStockLevel;
    public bool IsOutOfStock => Quantity == 0;
}
