using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner_api_auth.Requests
{
    public class GetOrderResponsesFilteredRequest
    {
        public GetOrderResponsesFilteredRequest(
            int orderId,
            string type,
            DateTime dateAfter,
            DateTime dateBefore,
            string content)
        {
            OrderId = orderId;
            Type = type;
            DateAfter = dateAfter;
            DateBefore = dateBefore;
            Content = content;
        }

        public int OrderId { get; private set; }
        public string Type { get; private set; }
        public DateTime? DateAfter { get; private set; }
        public DateTime? DateBefore { get; private set; }
        public string Content { get; private set; }
    }
}
