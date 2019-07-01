using MediatR;
using Optional;
using System;
using System.Collections.Generic;
using System.Text;
using WebScanner_api_auth.Domain.Models;

namespace WebScanner_api_auth.Domain.Commands
{
    public class AddHtmlOrderCommand : IRequest<Option<HOrder>>
    {
        public AddHtmlOrderCommand(string userId, int frequency, string targetAddress, string subjectOfQuestion)
        {
            UserId = userId;
            Frequency = frequency;
            TargetAddress = targetAddress;
            SubjectOfQuestion = subjectOfQuestion;
        }

        public string UserId { get; set; }
        public int Frequency { get; set; }
        public string TargetAddress { get; set; }
        public string SubjectOfQuestion { get; set; }
    }
}
