using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CVBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterUser _userService;

        public RegisterController(IRegisterUser userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password, string email, string firstName, string lastName)
        {
            // Validate the user data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the username is already taken
            if (_userService.IsUsernameTaken(username))
            {
                return Conflict("Username is already taken.");
            }

            // Register the user
            User registeredUser = await _userService.RegisterUserAsync(username, password, email, firstName, lastName);

            // Return the registered user
            return Ok(registeredUser);
        }
    }
}
