using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetByBusinessAsync(int businessId);
        Task<CustomerModel?> GetByIdAsync(int id);
        Task<CustomerModel> CreateAsync(CustomerModel customer);
        Task<CustomerModel> UpdateAsync(CustomerModel customer);
        Task<bool> DeleteAsync(int id);
        Task<List<CustomerModel>> GetTopCustomersAsync(int businessId, int count = 10);
        Task UpdateCustomerStatsAsync(int customerId, decimal purchaseAmount);
        Task<int> AddLoyaltyPointsAsync(int customerId, int points);
    }
}
