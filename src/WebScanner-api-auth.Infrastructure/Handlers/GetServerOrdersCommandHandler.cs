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
    public class GetServerOrdersCommandHandler : IRequestHandler<GetServerOrdersCommand, Option<IEnumerable<SOrder>>>
    {
        private readonly IOrderRepository _repository;

        public GetServerOrdersCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<IEnumerable<SOrder>>> Handle(GetServerOrdersCommand request, CancellationToken cancellationToken)
        {
            return await _repository.GetServerOrderForUser(request.UserId);
        }
    }
}
