using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebScanner_api_auth.Infrastructure.Models;

namespace WebScanner_api_auth.Infrastructure.DataContexts
{
    public class DatabaseContext : IdentityDbContext<WebScannerUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<OrderResponse> Responses { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }
        public DbSet<HtmlOrder> HtmlOrders { get; set; }
        public DbSet<ServerOrder> ServerOrders { get; set; }
    }
    
}
