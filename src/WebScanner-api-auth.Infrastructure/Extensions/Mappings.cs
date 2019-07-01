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

        public static IEnumerable<HOrder> MapHtmlOrdersToHOrders(this IEnumerable<HtmlOrder> orders)
        {
            return orders.Select(x => new HOrder(x.Id, x.Frequency, x.TargetAddress, x.SubjectOfQuestion));
        }

        public static IEnumerable<SOrder> MapServerOrdersToSOrders(this IEnumerable<ServerOrder> orders)
        {
            return orders.Select(x => new SOrder(x.Id, x.Frequency, x.TargetAddress, x.Question));
        }

        public static HOrder MapHtmlOrderToHOrder(this HtmlOrder order)
        {
            return new HOrder(order.Id, order.Frequency, order.TargetAddress, order.SubjectOfQuestion);
        }

        public static SOrder MapServerOrderToSOrder(this ServerOrder order)
        {
            return new SOrder(order.Id, order.Frequency, order.TargetAddress, order.Question);
        }
    }
}
