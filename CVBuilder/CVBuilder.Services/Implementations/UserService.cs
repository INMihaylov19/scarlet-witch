using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVBuilder.Models;
using CVBuilder.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;


namespace CVBuilder.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly CvdatabaseContext _context;

        public UserService(CvdatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> UpdateUserAsync(Guid id, User user)
        {
            if (id != user.Id)
            {
                return false;
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.Id = Guid.NewGuid();
            user.Password = EncryptWithSalt(user.Password, user.Salt);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        public bool GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            return _context.Users.Any(u => u.Username == username && u.Password == password);
        }

        public string EncryptWithSalt(string input, byte[] salt)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            byte[] saltedInputBytes = new byte[salt.Length + inputBytes.Length];
            Buffer.BlockCopy(salt, 0, saltedInputBytes, 0, salt.Length);
            Buffer.BlockCopy(inputBytes, 0, saltedInputBytes, salt.Length, inputBytes.Length);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(saltedInputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
