using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebScanner_api_auth.Domain.Models;
using WebScanner_api_auth.Infrastructure.Models;
using WebScanner_api_auth.Infrastructure.Repositories.RefitDto;

namespace WebScanner_api_auth.Infrastructure.Repositories
{
    public interface WebScannerRepository
    {
        [Post("/api/htmlorders")]
        [Headers("Content-Type: application/json")]
        Task<int> AddHtmlOrder([FromBody] HOrder order);

        [Post("/api/serverorders")]
        [Headers("Content-Type: application/json")]
        Task<int> AddServerOrder([FromBody] ServerOrderDto order);

        [Get("/api/htmlorders")]
        Task<HtmlOrder> GetHtmlOrder([FromQuery] int orderId);

        [Get("/api/serverorders")]
        Task<ServerOrder> GetServerOrder([FromQuery] int orderId);

        [Delete("/api/htmlorders")]
        Task<int> DeleteHtmlOrder([FromQuery] int orderId);

        [Delete("/api/serverorders")]
        Task<int> DeleteServerOrder([FromQuery] int orderId);

    }
}
