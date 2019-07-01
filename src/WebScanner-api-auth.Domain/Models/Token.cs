using System;
using System.Collections.Generic;
using System.Text;

namespace WebScanner_api_auth.Domain.Models
{
    public class Token
    {
        public Token(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
    }
}
