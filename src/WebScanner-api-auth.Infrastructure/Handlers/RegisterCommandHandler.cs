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
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Option<User>>
    {
        private readonly IAuthenticationRepository _repository;

        public RegisterCommandHandler(IAuthenticationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<User>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Register(request.UserName, request.Password);
        }
    }
}
