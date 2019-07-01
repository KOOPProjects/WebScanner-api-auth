using MediatR;
using Optional;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebScanner_api_auth.Domain.Commands;
using WebScanner_api_auth.Domain.Models;
using WebScanner_api_auth.Domain.Repositories;
using WebScanner_api_auth.Infrastructure.Repositories;

namespace WebScanner_api_auth.Infrastructure.Handlers
{
    public class AddServerOrderCommandHandler : IRequestHandler<AddServerOrderCommand, Option<SOrder>>
    {
        private readonly IOrderRepository _repository;

        public AddServerOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<SOrder>> Handle(AddServerOrderCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddServerOrder(new SOrder(request.Frequency, request.TargetAddress, request.Question), request.UserId);
        }
    }
}
