using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Services.Interface;


namespace WebApplication2.Services.Repository
{
    public class ValidationService : IValidationService
    {

        private readonly IEntranceRepository _entranceRepository;
        public ValidationService(IEntranceRepository entranceRepository)
        {
            _entranceRepository = entranceRepository;
        }

        public async Task<bool> CheckIfEmailExists(string email)
        {
            try
            {
                UserModel userModel = await _entranceRepository.GetByEmail(email);
                if (userModel == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
