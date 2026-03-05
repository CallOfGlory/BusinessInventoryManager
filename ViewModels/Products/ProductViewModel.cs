using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.Products;

public class ProductViewModel
{
    
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Price is required")]
    [Range(minimum:0.01, maximum: int.MaxValue, ErrorMessage = "Price must be > 0.01")]
    public double Price { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    [Length(minimumLength: 10, maximumLength: 2000,  ErrorMessage = "Description must be more than 10 and less then 2000 characters")]
    public string Description { get; set; }
    public string Category { get; set; }
}