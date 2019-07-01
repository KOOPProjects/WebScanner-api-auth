using MediatR;
using Optional;
using System;
using System.Collections.Generic;
using System.Text;
using WebScanner_api_auth.Domain.Models;

namespace WebScanner_api_auth.Domain.Commands
{
    public class GetServerOrdersCommand : IRequest<Option<IEnumerable<SOrder>>>
    {
        public GetServerOrdersCommand(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}
