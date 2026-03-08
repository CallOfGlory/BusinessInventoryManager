using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Helpers;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationContext _context;

        public ProfileService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<UserModel?> GetUserByIdAsync(int userId)
        {
            return await _context.Users
                .Include(u => u.Businesses)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task UpdateProfileAsync(UserModel user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
                throw new KeyNotFoundException("User not found");

            existingUser.Username = user.Username;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Phone = user.Phone;
            existingUser.ProfileImage = user.ProfileImage;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;

            // Verify current password
            if (!PasswordHelper.VerifyPassword(currentPassword, user.PasswordHash))
                return false;

            // Update to new password
            user.PasswordHash = PasswordHelper.HashPassword(newPassword);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ValidatePasswordAsync(int userId, string password)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;

            return PasswordHelper.VerifyPassword(password, user.PasswordHash);
        }
    }
}
