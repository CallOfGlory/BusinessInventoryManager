using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface IEnteranceService
    {
        public Task<UserModel> LoginAsync(UserModel user);
        public Task<UserModel> RegisterAsync(UserModel userModel);

    }
}
