using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationContext _context;

        public SupplierService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<SupplierModel>> GetByBusinessAsync(int businessId)
        {
            return await _context.Set<SupplierModel>()
                .Where(s => s.BusinessId == businessId && s.IsActive)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<SupplierModel?> GetByIdAsync(int id)
        {
            return await _context.Set<SupplierModel>().FindAsync(id);
        }

        public async Task<SupplierModel> CreateAsync(SupplierModel supplier)
        {
            supplier.CreatedAt = DateTime.UtcNow;
            supplier.UpdatedAt = DateTime.UtcNow;
            _context.Set<SupplierModel>().Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<SupplierModel> UpdateAsync(SupplierModel supplier)
        {
            supplier.UpdatedAt = DateTime.UtcNow;
            _context.Set<SupplierModel>().Update(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var supplier = await _context.Set<SupplierModel>().FindAsync(id);
            if (supplier == null) return false;
            supplier.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SupplierModel>> SearchAsync(int businessId, string term)
        {
            return await _context.Set<SupplierModel>()
                .Where(s => s.BusinessId == businessId && s.IsActive &&
                    (s.Name.Contains(term) || (s.Email != null && s.Email.Contains(term))))
                .ToListAsync();
        }
    }
}
