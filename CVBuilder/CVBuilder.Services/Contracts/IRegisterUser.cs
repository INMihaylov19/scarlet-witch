using CVBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.Contracts
{
    public interface IRegisterUser
    {
        Task<User> RegisterUserAsync(string username, string password, string email, string firstName, string lastName);
        bool IsUsernameTaken(string username);
    }
}
