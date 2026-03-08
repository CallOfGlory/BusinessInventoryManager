using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface IBusinessService
    {
        Task<BusinessModel?> GetBusinessByIdAsync(int id, int userId);
        Task<IEnumerable<BusinessModel>> GetUserBusinessesAsync(int userId);
        Task<BusinessModel?> GetActiveBusinessAsync(int userId);
        Task<BusinessModel> CreateBusinessAsync(BusinessModel business);
        Task<BusinessModel> UpdateBusinessAsync(BusinessModel business);
        Task<bool> DeleteBusinessAsync(int id, int userId);
        Task<bool> SetActiveBusinessAsync(int userId, int businessId);
    }
}
