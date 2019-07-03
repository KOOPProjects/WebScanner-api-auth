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
    public class GetHtmlOrderCommandHandler : IRequestHandler<GetHtmlOrderCommand, Option<HOrder>>
    {
        private readonly IOrderRepository _repository;

        public GetHtmlOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<HOrder>> Handle(GetHtmlOrderCommand request, CancellationToken cancellationToken)
        {
            return await _repository.GetHtmlOrder(request.UserId, request.OrderId);
        }
    }
}
