using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebScanner_api_auth.Infrastructure.Models
{
    public class UserOrder : DatabaseEntity
    {
        public UserOrder(string userId, int orderId, string type)
        {
            UserId = userId;
            OrderId = orderId;
            Type = type;
        }

        public string UserId { get; set; }
        public int OrderId { get; set; }
        public string Type { get; set; }
    }
}
