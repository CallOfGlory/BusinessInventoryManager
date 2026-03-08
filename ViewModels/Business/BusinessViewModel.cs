using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.Business
{
    public class BusinessViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Business name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        [Display(Name = "Business Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        [Display(Name = "Currency")]
        public string Currency { get; set; } = "USD";

        [Required(ErrorMessage = "Currency symbol is required")]
        [StringLength(5, ErrorMessage = "Currency symbol cannot exceed 5 characters")]
        [Display(Name = "Currency Symbol")]
        public string CurrencySymbol { get; set; } = "$";

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Statistics
        public int ProductCount { get; set; }
        public int TransactionCount { get; set; }
        public double TotalInventoryValue { get; set; }
    }

    public class BusinessListViewModel
    {
        public IEnumerable<BusinessViewModel> Businesses { get; set; } = new List<BusinessViewModel>();
        public int ActiveBusinessId { get; set; }
    }

    public class CreateBusinessViewModel
    {
        [Required(ErrorMessage = "Business name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        [Display(Name = "Business Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        [Display(Name = "Currency")]
        public string Currency { get; set; } = "USD";

        [Required(ErrorMessage = "Currency symbol is required")]
        [StringLength(5, ErrorMessage = "Currency symbol cannot exceed 5 characters")]
        [Display(Name = "Currency Symbol")]
        public string CurrencySymbol { get; set; } = "$";
    }
}
