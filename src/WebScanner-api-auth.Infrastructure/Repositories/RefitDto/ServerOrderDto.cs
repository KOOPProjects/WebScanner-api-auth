using System;
using System.Collections.Generic;
using System.Text;

namespace WebScanner_api_auth.Infrastructure.Repositories.RefitDto
{
    public class ServerOrderDto
    {
        public ServerOrderDto(int frequency, string targetAddress, string question)
        {
            Frequency = frequency;
            TargetAddress = targetAddress;
            Question = question;
        }

        public int Frequency { get; set; }
        public string TargetAddress { get; set; }
        public string Question { get; set; }
    }
}
