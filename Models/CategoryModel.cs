namespace WebApplication2.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Color { get; set; } // For UI display
        public string? Icon { get; set; }
        public int? ParentCategoryId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public BusinessModel? Business { get; set; }
        public CategoryModel? ParentCategory { get; set; }
        public ICollection<CategoryModel> SubCategories { get; set; } = new List<CategoryModel>();
        public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
