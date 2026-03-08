using WebApplication2.Models;

namespace WebApplication2.Interface
{
    public interface IBusinessRepository
    {
        Task<BusinessModel> AddAsync(BusinessModel business);
        Task<BusinessModel?> GetByIdAsync(int id);
        Task<List<BusinessModel>> GetByUserIdAsync(int userId);
        Task UpdateAsync(BusinessModel business);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id, int userId);
    }
}
