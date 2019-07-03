using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Optional;
using Refit;
using WebScanner_api_auth.Domain.Models;
using WebScanner_api_auth.Domain.Repositories;
using WebScanner_api_auth.Infrastructure.DataContexts;
using WebScanner_api_auth.Infrastructure.Extensions;
using WebScanner_api_auth.Infrastructure.Models;

namespace WebScanner_api_auth.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseContext _context;
        private readonly WebScannerRepository _webScannerRepository;

        public OrderRepository(DatabaseContext context, WebScannerRepository webScannerRepository)
        {
            _context = context;
            _webScannerRepository = webScannerRepository;
        }

        public async Task<Option<HOrder>> AddHtmlOrder(HOrder order, string userId)
        {
            var apiResult = await _webScannerRepository.AddHtmlOrder(order);
            var result = _context.UserOrders.Add(new UserOrder(userId, apiResult, "Html"));
            await _context.SaveChangesAsync();
            var addedOrder = await _context.HtmlOrders.FirstOrDefaultAsync(x => x.Id == apiResult);
            if(addedOrder != null)
            {
                return Option.Some<HOrder>(addedOrder.MapHtmlOrderToHOrder());
            }
            else
            {
                return Option.None<HOrder>();
            }
        }

        public async Task<Option<SOrder>> AddServerOrder(SOrder order, string userId)
        {
            var apiResult = await _webScannerRepository.AddServerOrder(new RefitDto.ServerOrderDto(order.Frequency, order.TargetAddress, order.Question));
            var result = _context.UserOrders.Add(new UserOrder(userId, apiResult, "Server"));
            await _context.SaveChangesAsync();
            var addedOrder = await _context.ServerOrders.FirstOrDefaultAsync(x => x.Id == apiResult);
            if (addedOrder != null)
            {
                return Option.Some<SOrder>(addedOrder.MapServerOrderToSOrder());
            }
            else
            {
                return Option.None<SOrder>();
            }
        }

        public async Task<Option<int>> DeleteHtmlOrder(string userId, int orderId)
        {
            var userOrder = await _context.UserOrders.FirstOrDefaultAsync(x => x.OrderId == orderId && x.UserId == userId && x.Type == "Html");
            if (userOrder != null)
            {
                try
                {
                    _context.UserOrders.Remove(userOrder);
                    var id = await _webScannerRepository.DeleteHtmlOrder(orderId);
                    await _context.SaveChangesAsync();
                    return Option.Some<int>(id);
                }
                catch (Exception e)
                {
                    return Option.None<int>();
                }
            }
            else
            {
                return Option.None<int>();
            }
        }

        public async Task<Option<int>> DeleteServerOrder(string userId, int orderId)
        {
            var userOrder = await _context.UserOrders.FirstOrDefaultAsync(x => x.OrderId == orderId && x.UserId == userId && x.Type == "Server");
            if (userOrder != null)
            {
                try
                {
                    _context.UserOrders.Remove(userOrder);
                    var id = await _webScannerRepository.DeleteServerOrder(orderId);
                    await _context.SaveChangesAsync();
                    return Option.Some<int>(id);
                }
                catch (Exception e)
                {
                    return Option.None<int>();
                }
            }
            else
            {
                return Option.None<int>();
            }
        }

        public async Task<Option<HOrder>> GetHtmlOrder(string userId, int orderId)
        {
            if (await _context.UserOrders.FirstOrDefaultAsync(x => x.OrderId == orderId && x.UserId == userId && x.Type == "Html") != null)
            {
                var order = await _webScannerRepository.GetHtmlOrder(orderId);
                if (order != null)
                {
                    return Option.Some<HOrder>(new HOrder(orderId, order.Frequency, order.TargetAddress, order.SubjectOfQuestion));
                }
                else
                {
                    return Option.None<HOrder>();
                }
            }
            else
            {
                return Option.None<HOrder>();
            }
        }

        public async Task<Option<IEnumerable<HOrder>>> GetHtmlOrderForUser(string userId)
        {
            var userOrdersIds = _context.UserOrders.Where(x => x.Type == "Html" && x.UserId == userId).Select(x => x.OrderId);
            var orders = await _context.HtmlOrders.Where(x => userOrdersIds.Contains(x.Id)).ToListAsync();
            if(orders != null)
            {
                return Option.Some<IEnumerable<HOrder>>(orders.MapHtmlOrdersToHOrders());
            }
            else
            {
                return Option.None<IEnumerable<HOrder>>();
            }
        }

        public async Task<Option<SOrder>> GetServerOrder(string userId, int orderId)
        {
            if (await _context.UserOrders.FirstOrDefaultAsync(x => x.OrderId == orderId && x.UserId == userId && x.Type == "Server") != null)
            {
                var order = await _webScannerRepository.GetServerOrder(orderId);
                if(order != null)
                {
                    return Option.Some<SOrder>(new SOrder(orderId, order.Frequency, order.TargetAddress, order.Question));
                }
                else
                {
                    return Option.None<SOrder>();
                }
            }
            else
            {
                return Option.None<SOrder>();
            }
        }

        public async Task<Option<IEnumerable<SOrder>>> GetServerOrderForUser(string userId)
        {
            var userOrdersIds = _context.UserOrders.Where(x => x.Type == "Server" && x.UserId == userId).Select(x => x.OrderId);
            var orders = await _context.ServerOrders.Where(x => userOrdersIds.Contains(x.Id)).ToListAsync();
            if(orders != null)
            {
                return Option.Some<IEnumerable<SOrder>>(orders.MapServerOrdersToSOrders());
            }
            else
            {
                return Option.None<IEnumerable<SOrder>>();
            }
        }
    }
}
