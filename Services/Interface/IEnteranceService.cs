using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface IEnteranceService
    {
        Task<UserModel> LoginAsync(UserModel user);
        Task<UserModel> RegisterAsync(UserModel userModel);
        Task<UserModel> CreateUserAsync(UserModel userModel);
        Task<UserModel?> GetUserByIdAsync(int userId);
        Task<List<UserModel>> GetUsersByBusinessIdAsync(int businessId);
        Task<UserModel> UpdateUserAsync(UserModel user);
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
        Task<bool> DeleteUserAsync(int userId);
    }
}
