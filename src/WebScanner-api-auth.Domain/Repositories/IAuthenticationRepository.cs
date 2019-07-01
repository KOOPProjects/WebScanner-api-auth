using Optional;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebScanner_api_auth.Domain.Models;

namespace WebScanner_api_auth.Domain.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<Option<Token>> Login(string username, string password);
        Task<Option<User>> Register(string username, string password);

    }
}
