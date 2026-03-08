namespace WebApplication2.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ProfileImage { get; set; } = string.Empty;
        public int? ActiveBusinessId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }

        // Navigation properties
        public ICollection<BusinessModel> Businesses { get; set; } = new List<BusinessModel>();
        public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
