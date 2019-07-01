using MediatR;
using Optional;
using System;
using System.Collections.Generic;
using System.Text;
using WebScanner_api_auth.Domain.Models;

namespace WebScanner_api_auth.Domain.Commands
{
    public class GetOrderResponsesFilteredCommand : IRequest<Option<IEnumerable<Response>>>
    {
        public GetOrderResponsesFilteredCommand(
            int orderId,
            string type,
            DateTime? dateAfter,
            DateTime? dateBefore,
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
