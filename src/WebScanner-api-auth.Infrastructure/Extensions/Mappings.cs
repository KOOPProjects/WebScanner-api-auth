using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebScanner_api_auth.Domain.Models;
using WebScanner_api_auth.Infrastructure.Models;

namespace WebScanner_api_auth.Infrastructure.Extensions
{
    public static class Mappings
    {
        public static User MapWebScannerUserToUser(this WebScannerUser user)
        {
            return new User(user.Id, user.UserName);
        }
        
        public static IEnumerable<Response> MapOrderResponsestoResponses(this IEnumerable<OrderResponse> responses)
        {
            return responses.Select(x => new Response(x.Id, x.OrderId, x.Date, x.Content, x.Type));
        }
    }
}
