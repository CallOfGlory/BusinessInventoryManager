using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class EnteranceService : IEnteranceService
    {
        private readonly IEntranceRepository _entranceRepository;
        private readonly IPasswordService _passwordService;
        private readonly IBusinessRepository _businessRepository;

        public EnteranceService(
            IEntranceRepository entranceRepository, 
            IPasswordService passwordService,
            IBusinessRepository businessRepository)
        {
            _entranceRepository = entranceRepository;
            _passwordService = passwordService;
            _businessRepository = businessRepository;
        }

        public async Task<UserModel> LoginAsync(UserModel userModel)
        {
            UserModel? userReceived = await _entranceRepository.GetByEmail(userModel.Email);
            
            if (userReceived == null)
            {
                throw new Exception("Invalid email or password");
            }

            // Verify password hash
            if (!_passwordService.VerifyPassword(userModel.PasswordHash, userReceived.PasswordHash))
            {
                throw new Exception("Invalid email or password");
            }

            // Update last login
            userReceived.LastLoginAt = DateTime.UtcNow;
            await _entranceRepository.Update(userReceived);

            return userReceived;
        }

        public async Task<UserModel> RegisterAsync(UserModel userModel)
        {
            UserModel? existingUser = await _entranceRepository.GetByEmail(userModel.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }

            // Hash the password
            string passwordHash = _passwordService.HashPassword(userModel.PasswordHash);

            UserModel newUser = new UserModel
            {
                Email = userModel.Email,
                PasswordHash = passwordHash,
                Username = userModel.Username ?? userModel.Email.Split('@')[0],
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            UserModel registeredUser = await _entranceRepository.Add(newUser);

            // Create a default business for the new user
            var defaultBusiness = new BusinessModel
            {
                UserId = registeredUser.Id,
                Name = "My Business",
                Description = "Default business",
                Currency = "USD",
                CurrencySymbol = "$",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _businessRepository.AddAsync(defaultBusiness);

            return registeredUser;
        }

        public async Task<UserModel?> GetUserByIdAsync(int userId)
        {
            return await _entranceRepository.GetById(userId);
        }

        public async Task<UserModel> UpdateUserAsync(UserModel user)
        {
            user.UpdatedAt = DateTime.UtcNow;
            return await _entranceRepository.Update(user);
        }

        public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _entranceRepository.GetById(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (!_passwordService.VerifyPassword(currentPassword, user.PasswordHash))
            {
                throw new Exception("Current password is incorrect");
            }

            user.PasswordHash = _passwordService.HashPassword(newPassword);
            user.UpdatedAt = DateTime.UtcNow;
            await _entranceRepository.Update(user);

            return true;
        }
    }
}
