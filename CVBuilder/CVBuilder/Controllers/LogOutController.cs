using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CVBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            // Perform user logout
            await HttpContext.SignOutAsync();

            return Ok("Logged out successfully.");
        }
    }
}