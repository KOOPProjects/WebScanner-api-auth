using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScanner_api_auth.Requests
{
    public class AddHtmlOrderRequest
    {
        public int Frequency { get; set; }
        public string TargetAddress { get; set; }
        public string SubjectOfQuestion { get; set; }
    }
}
