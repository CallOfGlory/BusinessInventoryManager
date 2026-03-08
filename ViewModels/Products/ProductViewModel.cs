using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.Products;

public class ProductViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public string? SKU { get; set; }

    [Required(ErrorMessage = "Purchase Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be > 0")]
    [Display(Name = "Purchase Price")]
    public double PurchasePrice { get; set; }

    [Required(ErrorMessage = "Sale Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Sale Price must be > 0")]
    [Display(Name = "Sale Price")]
    public double SalePrice { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be >= 0")]
    public int Quantity { get; set; }

    [Display(Name = "Min Stock Level")]
    public int? MinStockLevel { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    public string? Category { get; set; }

    public bool IsLowStock { get; set; }
    public DateTime CreatedAt { get; set; }
}
