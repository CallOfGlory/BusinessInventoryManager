using System.Security.Claims;

namespace WebApplication2.Services.Interface
{
    public interface IClaimsService
    {
        public Task AddClaimsAsync(int Id, string Email, HttpContext context);
        public Task<List<Claim>> GetClaimsAsync(HttpContext context);
        public Task<int> GetClaimsIdAsync(HttpContext context);
        public Task<string> GetClaimsEmailAsync(HttpContext context);
        public Task<T> GetClaimCertain<T>(HttpContext context, string claimType);
    }
}
