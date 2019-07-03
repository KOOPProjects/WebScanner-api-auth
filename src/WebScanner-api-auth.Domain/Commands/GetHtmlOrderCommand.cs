using MediatR;
using Optional;
using System;
using System.Collections.Generic;
using System.Text;
using WebScanner_api_auth.Domain.Models;

namespace WebScanner_api_auth.Domain.Commands
{
    public class GetHtmlOrderCommand : IRequest<Option<HOrder>>
    {
        public GetHtmlOrderCommand(string userId, int orderId)
        {
            UserId = userId;
            OrderId = orderId;
        }

        public string UserId { get; set; }
        public int OrderId { get; set; }
    }
}
