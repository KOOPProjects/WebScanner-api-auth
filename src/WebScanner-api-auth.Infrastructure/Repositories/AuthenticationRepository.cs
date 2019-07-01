using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Optional;
using WebScanner_api_auth.Domain.Models;
using WebScanner_api_auth.Domain.Repositories;
using WebScanner_api_auth.Infrastructure.DataContexts;
using WebScanner_api_auth.Infrastructure.Dtos.Settings;
using WebScanner_api_auth.Infrastructure.Extensions;
using WebScanner_api_auth.Infrastructure.Models;
using WebScanner_api_auth.Infrastructure.Tokens;

namespace WebScanner_api_auth.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<WebScannerUser> _userManager;
        private readonly SignInManager<WebScannerUser> _signInManager;
        private readonly DatabaseContext _context;
        private readonly IOptions<AuthorizationSettings> _settings;

        public AuthenticationRepository(
            UserManager<WebScannerUser> userManager,
            SignInManager<WebScannerUser> signInManager,
            DatabaseContext context,
            IOptions<AuthorizationSettings> settings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _settings = settings;
        }

        public async Task<Option<Token>> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if(user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                await _signInManager.SignInAsync(user, true, null);
                return Option.Some<Token>(new Token(TokenGenerator.GenerateToken(_settings.Value, user.Id)));
            }
            else
            {
                return Option.None<Token>();
            }
        }

        public async Task<Option<User>> Register(string username, string password)
        {
            var result = await _userManager.CreateAsync(new WebScannerUser(username), password);
            if (result.Succeeded)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
                return Option.Some<User>(user.MapWebScannerUserToUser());
            }
            else
            {
                return Option.None<User>();
            }
        }
    }
}
