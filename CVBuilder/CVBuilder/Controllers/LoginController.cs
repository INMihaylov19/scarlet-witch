using Microsoft.AspNetCore.Mvc;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using CVBuilder.Data.DTO;

namespace CVBuilder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserService _userService;
        private readonly IConfiguration _configuration;
        public LoginController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO loginUser)
        {
            string hashedPassword = _userService.EncryptWithSalt(loginUser.Password, new byte[128 / 8]);
            bool userExists = _userService.GetUserByUsernameAndPasswordAsync(loginUser.Username, hashedPassword);

            if (!userExists)
            {
                return Unauthorized();
            }

            string token = CreatedToken(loginUser.Username, loginUser.Password);

            return Ok($"Login successful, {token}");
        }

        private string CreatedToken(string username, string password)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Authentication, password)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
