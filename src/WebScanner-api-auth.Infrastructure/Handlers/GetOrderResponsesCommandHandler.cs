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

namespace WebScanner_api_auth.Infrastructure.Handlers
{
    public class GetOrderResponsesCommandHandler : IRequestHandler<GetOrderResponsesCommand, Option<IEnumerable<Response>>>
    {
        private readonly IResponseRepository _repository;

        public GetOrderResponsesCommandHandler(IResponseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<IEnumerable<Response>>> Handle(GetOrderResponsesCommand request, CancellationToken cancellationToken)
        {
            return await _repository.GetOrderResponses(request.OrderId, request.OrderType);
        }
    }
}
