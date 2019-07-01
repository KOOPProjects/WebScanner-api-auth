using MediatR;
using Optional;
using System;
using System.Collections.Generic;
using System.Text;
using WebScanner_api_auth.Domain.Models;

namespace WebScanner_api_auth.Domain.Commands
{
    public class GetOrderResponsesCommand : IRequest<Option<IEnumerable<Response>>>
    {
        public GetOrderResponsesCommand(int orderId, string orderType)
        {
            OrderId = orderId;
            OrderType = orderType;
        }

        public int OrderId { get; set; }
        public string OrderType { get; set; }
    }
}
