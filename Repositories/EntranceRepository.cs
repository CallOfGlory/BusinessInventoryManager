using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Models.Enterance;
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

        public async Task<UserModel> Login(LoginModel loginModel)
        {
            UserModel userRecived = await _applicationContext.Users.FirstOrDefaultAsync(e => e.Email.ToString() == loginModel.Email);
            if (userRecived == null || userRecived.Password != loginModel.Password)
            {
                throw new Exception("Invalid email or password");
            }
            _applicationContext.SaveChanges();

            return userRecived;
        }

        public async Task<UserModel> Register(RegisterModel registerModel)
        {
            UserModel userRecived = await _applicationContext.Users.FirstOrDefaultAsync(e => e.Email.ToString() == registerModel.Email);
            if (userRecived != null)
            {
                throw new Exception("User with this email already exists");
            }

            UserModel user = new UserModel
            {
                Username = registerModel.Username,
                Email = registerModel.Email,
                Password = registerModel.Password
            };

            _applicationContext.Users.Add(user);
            await _applicationContext.SaveChangesAsync();

            return user;
        }
    }
}
