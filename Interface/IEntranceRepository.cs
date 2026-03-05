using WebApplication2.Models;

namespace WebApplication2.Interface
{
    public interface IEntranceRepository
    {
        Task<UserModel> Add(UserModel userModel);
        Task<UserModel> GetByEmail(string email);
        Task Update(UserModel userModel);
        Task Delete(int id);
    }
}
