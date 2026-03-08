using WebApplication2.Helpers;
using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class EnteranceService : IEnteranceService
    {
        private readonly IEntranceRepository _entranceRepository;
        private readonly IBusinessService _businessService;

        public EnteranceService(IEntranceRepository entranceRepository, IClaimsService claimsService, IBusinessService businessService)
        {
            _entranceRepository = entranceRepository;
            _businessService = businessService;
        }

        public async Task<UserModel> LoginAsync(UserModel userModel)
        {
            try
            {
                UserModel? userReceived = await _entranceRepository.GetByEmail(userModel.Email);
                if (userReceived == null)
                {
                    throw new Exception("Invalid email or password");
                }

                // Verify password using BCrypt
                if (!PasswordHelper.VerifyPassword(userModel.PasswordHash, userReceived.PasswordHash))
                {
                    throw new Exception("Invalid email or password");
                }

                // Update last login time
                userReceived.LastLoginAt = DateTime.UtcNow;
                await _entranceRepository.Update(userReceived);

                return userReceived;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> RegisterAsync(UserModel userModel)
        {
            try
            {
                UserModel? receivedUser = await _entranceRepository.GetByEmail(userModel.Email);
                if (receivedUser != null)
                {
                    throw new Exception("Email already exists");
                }

                // Hash the password before storing
                UserModel newUser = new UserModel
                {
                    Email = userModel.Email,
                    PasswordHash = PasswordHelper.HashPassword(userModel.PasswordHash),
                    Username = !string.IsNullOrEmpty(userModel.Username) ? userModel.Username : userModel.Email.Split('@')[0],
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    CreatedAt = DateTime.UtcNow
                };

                UserModel newRegistered = await _entranceRepository.Add(newUser);

                // Create a default business for the new user
                var defaultBusiness = new BusinessModel
                {
                    Name = "My Business",
                    Description = "Default business",
                    Currency = "USD"
                };
                await _businessService.CreateBusinessAsync(defaultBusiness, newRegistered.Id);

                return newRegistered;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
