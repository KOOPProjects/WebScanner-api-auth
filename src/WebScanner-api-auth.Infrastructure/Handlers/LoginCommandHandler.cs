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
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Option<Token>>
    {
        private readonly IAuthenticationRepository _repository;

        public LoginCommandHandler(IAuthenticationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Option<Token>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _repository.Login(request.UserName, request.Password);
            
        }
    }
}
