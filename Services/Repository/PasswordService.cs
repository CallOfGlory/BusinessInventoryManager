using WebApplication2.Services.Interface;
using BCryptNet = BCrypt.Net.BCrypt;

namespace WebApplication2.Services.Repository
{
    public class PasswordService : IPasswordService
    {
        private const int WorkFactor = 11;

        public string HashPassword(string password)
        {
            return BCryptNet.HashPassword(password, workFactor: WorkFactor);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            try
            {
                return BCryptNet.Verify(password, passwordHash);
            }
            catch
            {
                return false;
            }
        }
    }
}
