using CVBuilder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.Contracts
{
    public interface IUserService
    {
        public Task<List<User>> GetUsersAsync();
        public Task<User> GetUserByIdAsync(Guid id);
        public Task<bool> UpdateUserAsync(Guid id, User user);
        public Task<User> CreateUserAsync(User user);
        public Task<bool> DeleteUserAsync(Guid id);
        public bool UserExists(Guid id);
        public bool GetUserByUsernameAndPasswordAsync(string username, string password);
        public string EncryptWithSalt(string input, byte[] salt);
    }
}
