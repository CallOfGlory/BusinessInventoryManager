namespace WebApplication2.Services.Interface
{
    public interface IValidationService
    {
        Task<bool> CheckIfEmailExists(string email);
    }
}
