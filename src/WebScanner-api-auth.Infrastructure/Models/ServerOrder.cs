using System;
using System.Collections.Generic;
using System.Text;

namespace WebScanner_api_auth.Infrastructure.Models
{
    public class ServerOrder
    {
        public int Id { get; set; }
        public int Frequency { get; set; }
        public string TargetAddress { get; set; }
        public string Question { get; set; }
    }
}
