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
    public class GetOrderResponsesFilteredCommandHandler : IRequestHandler<GetOrderResponsesFilteredCommand, Option<IEnumerable<Response>>>
    {
        private readonly IResponseRepository _repository;

        public GetOrderResponsesFilteredCommandHandler(IResponseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<IEnumerable<Response>>> Handle(GetOrderResponsesFilteredCommand request, CancellationToken cancellationToken)
        {
            return await _repository.GetOrderResponsesFiltered(
                request.OrderId,
                request.Type,
                request.DateAfter,
                request.DateBefore,
                request.Content);
        }
    }
}
