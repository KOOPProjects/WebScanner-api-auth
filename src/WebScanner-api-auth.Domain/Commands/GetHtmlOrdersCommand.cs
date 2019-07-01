using MediatR;
using Optional;
using System;
using System.Collections.Generic;
using System.Text;
using WebScanner_api_auth.Domain.Models;

namespace WebScanner_api_auth.Domain.Commands
{
    public class GetHtmlOrdersCommand : IRequest<Option<IEnumerable<HOrder>>>
    {
        public GetHtmlOrdersCommand(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}
