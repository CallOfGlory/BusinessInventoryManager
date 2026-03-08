using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.Products;

public class ProductViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Range(minimum: 0.01, maximum: int.MaxValue, ErrorMessage = "Price must be > 0.01")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Sale Price required")]
    [Range(minimum: 0.01, maximum: int.MaxValue, ErrorMessage = "Sale Price must be > 0.01")]
    public double SalePrice { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity must be > 0")]
    public int Quantity { get; set; }
    [Required(ErrorMessage = "Description is required")]
    [Length(minimumLength: 10, maximumLength: 2000, ErrorMessage = "Description must be more than 10 and less then 2000 characters")]
    public string Description { get; set; }
    public string Category { get; set; }

    public DateTime CreatedAt { get; set; }
}