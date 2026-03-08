namespace WebApplication2.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Color { get; set; } = "#6c757d";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public BusinessModel Business { get; set; } = null!;
    }
}
