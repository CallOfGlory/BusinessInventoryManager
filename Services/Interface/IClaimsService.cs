namespace WebApplication2.Services.Interface
{
    public interface IClaimsService
    {
        public Task AddClaimsAsync(int Id, string Email, HttpContext context);
    }
}
