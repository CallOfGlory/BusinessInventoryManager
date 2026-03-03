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
    }
}
