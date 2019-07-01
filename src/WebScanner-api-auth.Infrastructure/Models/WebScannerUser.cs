using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebScanner_api_auth.Infrastructure.Models
{
    public class WebScannerUser : IdentityUser
    {
        public WebScannerUser() : base()
        {
        }

        public WebScannerUser(string userName) : base(userName)
        {
        }
    }
}
