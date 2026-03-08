using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services.Interface;

namespace WebApplication2.Controllers
{
    public class ValidationController : Controller
    {

        private readonly IValidationService _validationService;

        public ValidationController(IValidationService validationService)
        {
            _validationService = validationService;
        }

        public async Task<IActionResult> CheckEmail(string email)
        {
            bool emailExists = await _validationService.CheckIfEmailExists(email);
            if (emailExists)
            {
                return Json($"The email {email} is already in use.");
            }
            return Json(true);
        }
    }
}
