using WebApplication2.Models;

namespace WebApplication2.Interface
{
    public interface IEntranceRepository
    {
        Task<UserModel> Add(UserModel userModel);
        Task<UserModel?> GetByEmail(string email);
        Task<UserModel?> GetById(int id);
        Task<UserModel> Update(UserModel userModel);
        Task<bool> Delete(int id);
    }
}
