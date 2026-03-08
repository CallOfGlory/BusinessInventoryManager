using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.Business
{
    public class BusinessViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Business name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Currency is required")]
        public string Currency { get; set; } = "USD";

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string Address { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Statistics for display
        public int ProductCount { get; set; }
        public int TransactionCount { get; set; }
        public double TotalRevenue { get; set; }
        public double TotalProfit { get; set; }
    }
}
