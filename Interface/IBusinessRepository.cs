using WebApplication2.Models;

namespace WebApplication2.Interface
{
    public interface IBusinessRepository
    {
        Task<BusinessModel?> GetByIdAsync(int id);
        Task<IEnumerable<BusinessModel>> GetByUserIdAsync(int userId);
        Task<BusinessModel?> GetActiveBusinessAsync(int userId);
        Task<BusinessModel> AddAsync(BusinessModel business);
        Task<BusinessModel> UpdateAsync(BusinessModel business);
        Task<bool> DeleteAsync(int id);
        Task<bool> SetActiveBusinessAsync(int userId, int businessId);
    }
}
