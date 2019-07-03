using MediatR;
using Optional;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebScanner_api_auth.Domain.Commands;
using WebScanner_api_auth.Domain.Repositories;
using WebScanner_api_auth.Infrastructure.Repositories;

namespace WebScanner_api_auth.Infrastructure.Handlers
{
    public class DeleteServerOrderCommandHandler : IRequestHandler<DeleteServerOrderCommand, Option<int>>
    {
        private readonly IOrderRepository _repository;

        public DeleteServerOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<int>> Handle(DeleteServerOrderCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteServerOrder(request.UserId, request.OrderId);
        }
    }
}
