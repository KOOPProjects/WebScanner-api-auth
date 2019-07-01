using System;
using System.Collections.Generic;
using System.Text;

namespace WebScanner_api_auth.Domain.Models
{
    public class SOrder
    {
        public SOrder(int frequency, string targetAddress, string question)
        {
            Frequency = frequency;
            TargetAddress = targetAddress;
            Question = question;
        }

        public SOrder(int id, int frequency, string targetAddress, string question)
        {
            Id = id;
            Frequency = frequency;
            TargetAddress = targetAddress;
            Question = question;
        }

        public int Id { get; set; }
        public int Frequency { get; set; }
        public string TargetAddress { get; set; }
        public string Question { get; set; }
    }
}
