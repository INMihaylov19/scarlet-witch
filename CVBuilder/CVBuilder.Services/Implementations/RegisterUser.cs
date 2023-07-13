using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.Implementations
{
    public class RegisterUser : IRegisterUser
    {
        private readonly CvdatabaseContext _context;

        public RegisterUser(CvdatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterUserAsync(string username, string password, string email, string firstName, string lastName)
        {
            UserService userService = new UserService(_context);

            User user = new User
            {
                Id = new Guid(),
                Username = username,
                Password = userService.EncryptWithSalt(password, new byte[128/8]),
                Email = email,
                FirstName = firstName,
                LastName = lastName
            };
            // Add the user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public bool IsUsernameTaken(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }
    }
}
