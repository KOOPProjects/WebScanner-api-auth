using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebScanner_api_auth.Domain.Models;
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

    }
}
