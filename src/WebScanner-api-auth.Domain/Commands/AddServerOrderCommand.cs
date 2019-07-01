using MediatR;
using Optional;
using System;
using System.Collections.Generic;
using System.Text;
using WebScanner_api_auth.Domain.Models;

namespace WebScanner_api_auth.Domain.Commands
{
    public class AddServerOrderCommand : IRequest<Option<SOrder>>
    {
        public AddServerOrderCommand(string userId, int frequency, string targetAddress, string question)
        {
            UserId = userId;
            Frequency = frequency;
            TargetAddress = targetAddress;
            Question = question;
        }

        public string UserId { get; set; }
        public int Frequency { get; set; }
        public string TargetAddress { get; set; }
        public string Question { get; set; }
    }
}
