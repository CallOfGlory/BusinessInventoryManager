namespace WebApplication2.Models
{
    public enum UserRole
    {
        Admin = 0,
        Staff = 1
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public UserRole Role { get; set; } = UserRole.Admin;
        public int? BusinessId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginAt { get; set; }


        public ICollection<BusinessModel> Businesses { get; set; } = new List<BusinessModel>();
        public ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
        public UserSettingsModel? Settings { get; set; }
        public BusinessModel? Business { get; set; }
    }
}
