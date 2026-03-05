using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using WebApplication2.Services.Interface;

namespace WebApplication2.Services.Repository
{
    public class ClaimsService : IClaimsService
    {
        public async Task AddClaimsAsync(int Id, string Email, HttpContext context)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Email, Email)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await context.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));
        }
        public async Task<List<Claim>> GetClaimsAsync(HttpContext context)
        {
            try
            {
                var userClaims = context.User.Claims;
                var claim = userClaims.ToList();
                foreach (var c in claim)
                {
                    Console.WriteLine($"Claim Type: {c.Type}, Claim Value: {c.Value}");
                }
                return claim;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> GetClaimsEmailAsync(HttpContext context)
        {
            try
            {
                var userClaims = context.User.Claims;
                var claim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                return claim;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> GetClaimsIdAsync(HttpContext context)
        {
            try
            {
                var userClaims = context.User.Claims;
                var claim = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                int res = Int32.Parse(claim);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<T> GetClaimCertain<T>(HttpContext context, string claimType)
        {
            try
            {
                var claim = context.User.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;

                if (claim == null)
                {
                    throw new Exception($"Claim of type '{claimType}' not found.");
                }

                return (T)Convert.ChangeType(claim, typeof(T));
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting claim {claimType}: {ex.Message}");
            }
        }
    }
}
