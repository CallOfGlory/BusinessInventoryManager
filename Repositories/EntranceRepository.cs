using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Repositories
{
    public class EntranceRepository : IEntranceRepository
    {
        private readonly ApplicationContext _applicationContext;

        public EntranceRepository(ApplicationContext applicationContext, IClaimsService claimsService)
        {
            _applicationContext = applicationContext;
        }

        public async Task<UserModel> Add(UserModel userModel)
        {
            await _applicationContext.Users.AddAsync(userModel);
            await _applicationContext.SaveChangesAsync();
            return userModel;
        }

        public async Task Delete(int id)
        {
            _applicationContext.Users.Remove(new UserModel { Id = id });
            await _applicationContext.SaveChangesAsync();

        }

        public async Task<UserModel> GetByEmail(string email)
        {
            var user = await _applicationContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task Update(UserModel userModel)
        {
            var existingUser = await _applicationContext.Users.FindAsync(userModel.Id);
            if (existingUser != null)
            {
                existingUser.Username = userModel.Username;
                existingUser.Email = userModel.Email;
                existingUser.Password = userModel.Password;
                await _applicationContext.SaveChangesAsync();
            }
        }
    }
}
