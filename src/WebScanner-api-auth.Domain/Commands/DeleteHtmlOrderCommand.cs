using MediatR;
using Optional;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebScanner_api_auth.Domain.Commands
{
    public class DeleteHtmlOrderCommand : IRequest<Option<int>>
    {
        public DeleteHtmlOrderCommand(string userId, int orderId)
        {
            UserId = userId;
            OrderId = orderId;
        }

        public string UserId { get; set; }
        public int OrderId { get; set; }
    }
}
