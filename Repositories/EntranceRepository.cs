using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Interface;
using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class EntranceRepository : IEntranceRepository
    {
        private readonly ApplicationContext _context;

        public EntranceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<UserModel> Add(UserModel userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserModel?> GetByEmail(string email)
        {
            return await _context.Users
                .Include(u => u.Businesses)
                .Include(u => u.Settings)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserModel?> GetById(int id)
        {
            return await _context.Users
                .Include(u => u.Businesses)
                .Include(u => u.Settings)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserModel> Update(UserModel userModel)
        {
            var existingUser = await _context.Users.FindAsync(userModel.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            existingUser.Username = userModel.Username;
            existingUser.Email = userModel.Email;
            existingUser.PasswordHash = userModel.PasswordHash;
            existingUser.FirstName = userModel.FirstName;
            existingUser.LastName = userModel.LastName;
            existingUser.Phone = userModel.Phone;
            existingUser.UpdatedAt = DateTime.UtcNow;
            existingUser.LastLoginAt = userModel.LastLoginAt;

            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}
