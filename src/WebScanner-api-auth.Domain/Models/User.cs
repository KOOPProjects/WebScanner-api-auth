using System;
using System.Collections.Generic;
using System.Text;

namespace WebScanner_api_auth.Domain.Models
{
    public class User
    {
        public User(string id, string userName)
        {
            Id = id;
            UserName = userName;
        }

        public string Id { get; set; }
        public string UserName { get; set; }

    }
}
