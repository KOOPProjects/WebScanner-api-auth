using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner_api_auth.Responses
{
    public class UserResponse
    {
        public UserResponse(string id, string userName)
        {
            Id = id;
            UserName = userName;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
    }
}
