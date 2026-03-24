using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly IEntranceRepository _entranceRepository;

        public BusinessService(IBusinessRepository businessRepository, IEntranceRepository entranceRepository)
        {
            _businessRepository = businessRepository;
            _entranceRepository = entranceRepository;
        }

        public async Task<BusinessModel?> GetBusinessByIdAsync(int id, int userId)
        {
            var business = await _businessRepository.GetByIdAsync(id);
            if (business == null)
            {
                return null;
            }
            if (business.UserId == userId)
            {
                return business;
            }
            var user = await _entranceRepository.GetById(userId);
            if (user != null && user.Role == UserRole.Staff && user.BusinessId == business.Id)
            {
                return business;
            }
            return null;
        }

        public async Task<IEnumerable<BusinessModel>> GetUserBusinessesAsync(int userId)
        {
            var user = await _entranceRepository.GetById(userId);
            if (user != null && user.Role == UserRole.Staff && user.BusinessId.HasValue)
            {
                var business = await _businessRepository.GetByIdAsync(user.BusinessId.Value);
                return business == null ? Enumerable.Empty<BusinessModel>() : new[] { business };
            }
            return await _businessRepository.GetByUserIdAsync(userId);
        }

        public async Task<BusinessModel?> GetActiveBusinessAsync(int userId)
        {
            var user = await _entranceRepository.GetById(userId);
            if (user != null && user.Role == UserRole.Staff && user.BusinessId.HasValue)
            {
                return await _businessRepository.GetByIdAsync(user.BusinessId.Value);
            }
            return await _businessRepository.GetActiveBusinessAsync(userId);
        }

        public async Task<BusinessModel> CreateBusinessAsync(BusinessModel business)
        {
            return await _businessRepository.AddAsync(business);
        }

        public async Task<BusinessModel> UpdateBusinessAsync(BusinessModel business)
        {
            return await _businessRepository.UpdateAsync(business);
        }

        public async Task<bool> DeleteBusinessAsync(int id, int userId)
        {
            var business = await _businessRepository.GetByIdAsync(id);
            if (business == null || business.UserId != userId)
            {
                return false;
            }
            return await _businessRepository.DeleteAsync(id);
        }

        public async Task<bool> SetActiveBusinessAsync(int userId, int businessId)
        {
            var business = await _businessRepository.GetByIdAsync(businessId);
            if (business == null || business.UserId != userId)
            {
                return false;
            }
            return await _businessRepository.SetActiveBusinessAsync(userId, businessId);
        }
    }
}
