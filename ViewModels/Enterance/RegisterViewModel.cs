using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels.Enterance;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Enter Username")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Enter Email")]
    [EmailAddress(ErrorMessage = "Enter Email")]
    [Remote]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Enter Password")] // Додайте це
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")] // Додайте це
    public string Password { get; set; }
    
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ComfirmPassword { get; set; }
}