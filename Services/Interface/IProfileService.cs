using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface IProfileService
    {
        Task<UserModel?> GetUserByIdAsync(int userId);
        Task UpdateProfileAsync(UserModel user);
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
        Task<bool> ValidatePasswordAsync(int userId, string password);
    }
}
