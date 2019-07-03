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
    public class DeleteHtmlOrderCommandHandler : IRequestHandler<DeleteHtmlOrderCommand, Option<int>>
    {
        private readonly IOrderRepository _repository;

        public DeleteHtmlOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<int>> Handle(DeleteHtmlOrderCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteHtmlOrder(request.UserId, request.OrderId);
        }
    }
}
