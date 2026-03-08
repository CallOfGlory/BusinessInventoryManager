using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface IBusinessService
    {
        Task<BusinessModel> CreateBusinessAsync(BusinessModel business, int userId);
        Task<BusinessModel?> GetBusinessByIdAsync(int id, int userId);
        Task<List<BusinessModel>> GetUserBusinessesAsync(int userId);
        Task UpdateBusinessAsync(BusinessModel business, int userId);
        Task DeleteBusinessAsync(int id, int userId);
        Task SetActiveBusinessAsync(int businessId, int userId);
        Task<BusinessModel?> GetActiveBusinessAsync(int userId);
    }
}
