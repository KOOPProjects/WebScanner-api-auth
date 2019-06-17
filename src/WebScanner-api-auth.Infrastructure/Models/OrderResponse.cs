using System;
using System.Collections.Generic;
using System.Text;

namespace WebScanner_api_auth.Infrastructure.Models
{
    public class OrderResponse : DatabaseEntity
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }

        public OrderResponse(int id, int orderId, DateTime date, string content, string type)
        {
            Id = id;
            OrderId = orderId;
            Date = date;
            Content = content;
            Type = type;
        }
    }
}
