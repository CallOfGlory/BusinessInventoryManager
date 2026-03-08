using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationContext _context;

        public CustomerService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerModel>> GetByBusinessAsync(int businessId)
        {
            return await _context.Set<CustomerModel>()
                .Where(c => c.BusinessId == businessId && c.IsActive)
                .OrderByDescending(c => c.TotalPurchases)
                .ToListAsync();
        }

        public async Task<CustomerModel?> GetByIdAsync(int id)
        {
            return await _context.Set<CustomerModel>().FindAsync(id);
        }

        public async Task<CustomerModel> CreateAsync(CustomerModel customer)
        {
            customer.CreatedAt = DateTime.UtcNow;
            _context.Set<CustomerModel>().Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<CustomerModel> UpdateAsync(CustomerModel customer)
        {
            _context.Set<CustomerModel>().Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var customer = await _context.Set<CustomerModel>().FindAsync(id);
            if (customer == null) return false;
            customer.IsActive = false;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CustomerModel>> GetTopCustomersAsync(int businessId, int count = 10)
        {
            return await _context.Set<CustomerModel>()
                .Where(c => c.BusinessId == businessId && c.IsActive)
                .OrderByDescending(c => c.TotalPurchases)
                .Take(count)
                .ToListAsync();
        }

        public async Task UpdateCustomerStatsAsync(int customerId, decimal purchaseAmount)
        {
            var customer = await _context.Set<CustomerModel>().FindAsync(customerId);
            if (customer == null) return;

            customer.TotalPurchases += purchaseAmount;
            customer.TotalOrders += 1;
            customer.LastPurchaseDate = DateTime.UtcNow;
            customer.LoyaltyPoints += (int)(purchaseAmount / 10); // 1 point per $10

            // Update tier based on total purchases
            customer.Tier = customer.TotalPurchases switch
            {
                >= 10000 => CustomerTier.Platinum,
                >= 5000 => CustomerTier.Gold,
                >= 2000 => CustomerTier.Silver,
                >= 500 => CustomerTier.Bronze,
                _ => CustomerTier.Regular
            };

            await _context.SaveChangesAsync();
        }

        public async Task<int> AddLoyaltyPointsAsync(int customerId, int points)
        {
            var customer = await _context.Set<CustomerModel>().FindAsync(customerId);
            if (customer == null) return 0;
            customer.LoyaltyPoints += points;
            await _context.SaveChangesAsync();
            return customer.LoyaltyPoints;
        }
    }
}
