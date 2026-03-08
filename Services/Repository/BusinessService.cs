using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Services.Interface;
using WebApplication2.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Services.Repository
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly ApplicationContext _context;

        public BusinessService(IBusinessRepository businessRepository, ApplicationContext context)
        {
            _businessRepository = businessRepository;
            _context = context;
        }

        public async Task<BusinessModel> CreateBusinessAsync(BusinessModel business, int userId)
        {
            business.UserId = userId;
            business.CreatedAt = DateTime.UtcNow;
            business.IsActive = true;

            var createdBusiness = await _businessRepository.AddAsync(business);

            // If this is user's first business, set it as active
            var user = await _context.Users.FindAsync(userId);
            if (user != null && !user.ActiveBusinessId.HasValue)
            {
                user.ActiveBusinessId = createdBusiness.Id;
                await _context.SaveChangesAsync();
            }

            return createdBusiness;
        }

        public async Task<BusinessModel?> GetBusinessByIdAsync(int id, int userId)
        {
            var business = await _businessRepository.GetByIdAsync(id);
            if (business == null || business.UserId != userId)
                return null;
            return business;
        }

        public async Task<List<BusinessModel>> GetUserBusinessesAsync(int userId)
        {
            return await _businessRepository.GetByUserIdAsync(userId);
        }

        public async Task UpdateBusinessAsync(BusinessModel business, int userId)
        {
            var existing = await _businessRepository.GetByIdAsync(business.Id);
            if (existing == null || existing.UserId != userId)
                throw new UnauthorizedAccessException("Business not found or access denied");

            existing.Name = business.Name;
            existing.Description = business.Description;
            existing.Currency = business.Currency;
            existing.Address = business.Address;
            existing.Phone = business.Phone;
            existing.IsActive = business.IsActive;

            await _businessRepository.UpdateAsync(existing);
        }

        public async Task DeleteBusinessAsync(int id, int userId)
        {
            var business = await _businessRepository.GetByIdAsync(id);
            if (business == null || business.UserId != userId)
                throw new UnauthorizedAccessException("Business not found or access denied");

            await _businessRepository.DeleteAsync(id);

            // If deleted business was active, set another as active
            var user = await _context.Users.FindAsync(userId);
            if (user != null && user.ActiveBusinessId == id)
            {
                var remainingBusiness = await _context.Businesses
                    .Where(b => b.UserId == userId && b.Id != id)
                    .FirstOrDefaultAsync();
                user.ActiveBusinessId = remainingBusiness?.Id;
                await _context.SaveChangesAsync();
            }
        }

        public async Task SetActiveBusinessAsync(int businessId, int userId)
        {
            var business = await _businessRepository.GetByIdAsync(businessId);
            if (business == null || business.UserId != userId)
                throw new UnauthorizedAccessException("Business not found or access denied");

            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.ActiveBusinessId = businessId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<BusinessModel?> GetActiveBusinessAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user?.ActiveBusinessId == null)
            {
                // Return first business if no active business set
                return await _context.Businesses
                    .Where(b => b.UserId == userId)
                    .FirstOrDefaultAsync();
            }

            return await _businessRepository.GetByIdAsync(user.ActiveBusinessId.Value);
        }
    }
}
