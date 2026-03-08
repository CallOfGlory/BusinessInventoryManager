using WebApplication2.Models;

namespace WebApplication2.Services.Interface
{
    public interface ISupplierService
    {
        Task<List<SupplierModel>> GetByBusinessAsync(int businessId);
        Task<SupplierModel?> GetByIdAsync(int id);
        Task<SupplierModel> CreateAsync(SupplierModel supplier);
        Task<SupplierModel> UpdateAsync(SupplierModel supplier);
        Task<bool> DeleteAsync(int id);
        Task<List<SupplierModel>> SearchAsync(int businessId, string term);
    }
}
