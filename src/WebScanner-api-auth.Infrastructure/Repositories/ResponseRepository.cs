using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Optional;
using WebScanner_api_auth.Domain.Models;
using WebScanner_api_auth.Domain.Repositories;
using WebScanner_api_auth.Infrastructure.DataContexts;
using WebScanner_api_auth.Infrastructure.Extensions;

namespace WebScanner_api_auth.Infrastructure.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly DatabaseContext _context;

        public ResponseRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Option<IEnumerable<Response>>> GetOrderResponses(int orderId, string orderType)
        {
            var result = await _context.Responses.Where(x => x.OrderId == orderId
                && x.Type == orderType).ToListAsync();
            if(result == null || result.Count() == 0)
            {
                return Option.None<IEnumerable<Response>>();
            }
            else
            {
                return Option.Some<IEnumerable<Response>>(result.AsEnumerable().MapOrderResponsestoResponses());
            }
        }

        public async Task<Option<IEnumerable<Response>>> GetOrderResponsesFiltered(
            int orderId,
            string orderType,
            DateTime? dateAfter,
            DateTime? dateBefore,
            string content)
        {
            var responses = _context.Responses.Where(x => x.OrderId == orderId && x.Type == orderType);
            if(dateAfter != null)
            {
                responses = responses.Where(x => x.Date > dateAfter);
            }
            if(dateBefore != null)
            {
                responses = responses.Where(x => x.Date < dateBefore);
            }
            if (!string.IsNullOrEmpty(content))
            {
                responses = responses.Where(x => x.Content.Contains(content));
            }
            var result = await responses.ToListAsync();
            if (result == null || result.Count() == 0)
            {
                return Option.None<IEnumerable<Response>>();
            }
            else
            {
                return Option.Some<IEnumerable<Response>>(result.AsEnumerable().MapOrderResponsestoResponses());
            }
        }
    }
}
