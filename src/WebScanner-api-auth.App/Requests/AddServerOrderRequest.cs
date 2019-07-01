using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner_api_auth.Requests
{
    public class AddServerOrderRequest
    {
        public int Frequency { get; set; }
        public string TargetAddress { get; set; }
        public string Question { get; set; }
    }
}
