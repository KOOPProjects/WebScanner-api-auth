﻿using System;
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

        public async Task<Option<IEnumerable<Response>>> GetResponsesByOrderId(int orderId, string orderType)
        {
            var result = await _context.Responses.Where(x => x.OrderId == orderId
                && x.Type == orderType).ToListAsync();
            return Option.Some<IEnumerable<Response>>(result.AsEnumerable().MapOrderResponsestoResponses());
        }

        public async Task<Option<IEnumerable<Response>>> GetResponsesFilteredByDate(int orderId, string orderType, DateTime dateAfter, DateTime dateBefore)
        {
            var result = await _context.Responses.Where(x => x.OrderId == orderId
            && x.Type == orderType
            && x.Date > dateAfter
            && x.Date < dateBefore).ToListAsync();
            return Option.Some<IEnumerable<Response>>(result.AsEnumerable().MapOrderResponsestoResponses());
        }
    }
}
