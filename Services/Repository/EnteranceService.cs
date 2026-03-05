using WebApplication2.Interface;
using WebApplication2.Models;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class EnteranceService : IEnteranceService
    {
        private readonly IEntranceRepository _entranceRepository;
        public EnteranceService(IEntranceRepository entranceRepository, IClaimsService claimsService)
        {
            _entranceRepository = entranceRepository;
        }
        public async Task<UserModel> LoginAsync(UserModel userModel)
        {
            try
            {
                UserModel userRecived = await _entranceRepository.GetByEmail(userModel.Email);
                if (userModel.Password != userRecived.Password || userRecived == null)
                {
                    throw new Exception("Invalid email or password");
                }
                return userRecived;
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
                UserModel recivedUser = await _entranceRepository.GetByEmail(userModel.Email);
                if (recivedUser != null)
                {
                    throw new Exception("Email already exists");
                }

                UserModel newUser = new UserModel
                {
                    Email = userModel.Email,
                    Password = userModel.Password,
                    Username = userModel.Email.Split('@')[0]
                };
                UserModel newRegistered = await _entranceRepository.Add(newUser);
                return newRegistered;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
