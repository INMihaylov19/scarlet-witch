using Microsoft.AspNetCore.Mvc;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;

namespace CVBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;
        public LoginController (IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Login(string username, string password)
        {
            string hashedPassword = _userService.EncryptWithSalt(password, new byte[128 / 8]);
            bool userExists = _userService.GetUserByUsernameAndPasswordAsync(username, hashedPassword);

            if (!userExists)
            {
                return Unauthorized();
            }

            return Ok("Login successful");
        }
    }
}
