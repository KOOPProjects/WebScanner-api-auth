using MediatR;
using Optional;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebScanner_api_auth.Domain.Commands
{
    public class DeleteServerOrderCommand : IRequest<Option<int>>
    {
        public DeleteServerOrderCommand(string userId, int orderId)
        {
            UserId = userId;
            OrderId = orderId;
        }

        public string UserId { get; set; }
        public int OrderId { get; set; }
    }
}
