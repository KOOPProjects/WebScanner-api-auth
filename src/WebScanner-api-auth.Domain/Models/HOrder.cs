using System;
using System.Collections.Generic;
using System.Text;

namespace WebScanner_api_auth.Domain.Models
{
    public class HOrder
    {
        public HOrder(int frequency, string targetAddress, string subjectOfQuestion)
        {
            Frequency = frequency;
            TargetAddress = targetAddress;
            SubjectOfQuestion = subjectOfQuestion;
        }

        public HOrder(int id, int frequency, string targetAddress, string subjectOfQuestion)
        {
            Id = id;
            Frequency = frequency;
            TargetAddress = targetAddress;
            SubjectOfQuestion = subjectOfQuestion;
        }

        public int Id { get; set; }
        public int Frequency { get; set; }
        public string TargetAddress { get; set; }
        public string SubjectOfQuestion { get; set; }
    }
}
