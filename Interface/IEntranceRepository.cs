using WebApplication2.Models;
using WebApplication2.Models.Enterance;

namespace WebApplication2.Interface
{
    public interface IEntranceRepository
    {
        Task<UserModel> Login(LoginModel loginModel);
        Task<UserModel> Register(RegisterModel registerModel);
    }
}
