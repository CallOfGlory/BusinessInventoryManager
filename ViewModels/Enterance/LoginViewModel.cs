namespace WebApplication2.ViewModels.Enterance;
using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required]
    [EmailAddress(ErrorMessage = "Email is not valid")]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}