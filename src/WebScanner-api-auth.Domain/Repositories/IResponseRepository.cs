using Optional;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebScanner_api_auth.Domain.Models;

namespace WebScanner_api_auth.Domain.Repositories
{
    public interface IResponseRepository
    {
        Task<Option<IEnumerable<Response>>> GetOrderResponses(int orderId, string orderType);
        Task<Option<IEnumerable<Response>>> GetOrderResponsesFiltered(int orderId, string orderType, DateTime? dateAfter, DateTime? dateBefore, string content);
    }
}
