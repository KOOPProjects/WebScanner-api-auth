using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WebScanner_api_auth.Infrastructure.Tokens
{
    public static class TokenDecryptor
    {
        public static string DecryptUserId(ClaimsIdentity claims)
        {
            return claims.FindFirst(ClaimTypes.Name)?.Value;
        }
    }

}
