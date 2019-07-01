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
    public class AddHtmlOrderCommandHandler : IRequestHandler<AddHtmlOrderCommand, Option<HOrder>>
    {
        private readonly IOrderRepository _repository;

        public AddHtmlOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<HOrder>> Handle(AddHtmlOrderCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddHtmlOrder(new HOrder(request.Frequency, request.TargetAddress, request.SubjectOfQuestion), request.UserId);
        }
    }
}
