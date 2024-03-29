﻿using Optional;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebScanner_api_auth.Domain.Models;

namespace WebScanner_api_auth.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Option<IEnumerable<HOrder>>> GetHtmlOrderForUser(string userId);
        Task<Option<IEnumerable<SOrder>>> GetServerOrderForUser(string userId);

        Task<Option<HOrder>> AddHtmlOrder(HOrder order, string userId);
        Task<Option<SOrder>> AddServerOrder(SOrder order, string userId);
        Task<Option<HOrder>> GetHtmlOrder(string userId, int orderId);
        Task<Option<SOrder>> GetServerOrder(string userId, int orderId);
        Task<Option<int>> DeleteServerOrder(string userId, int orderId);
        Task<Option<int>> DeleteHtmlOrder(string userId, int orderId);
    }
}
