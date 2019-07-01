using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebScanner_api_auth.Domain.Commands;
using WebScanner_api_auth.Requests;
using WebScanner_api_auth.Responses;
using WebScanner_api_auth.Validators;

namespace WebScanner_api_auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _bus;
        private readonly LoginRequestValidator _loginValidator;
        private readonly RegisterRequestValidator _registerValidator;

        public AuthController(
            IMediator bus,
            LoginRequestValidator loginValidator,
            RegisterRequestValidator registerValidator)
        {
            _bus = bus;
            _loginValidator = loginValidator;
            _registerValidator = registerValidator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var validationResult = _loginValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.First().ErrorMessage);
            }
            var result = await _bus.Send(new LoginCommand(request.UserName, request.Password));
            return result.Match<IActionResult>(
                some: x => Ok(new TokenResponse { Token = x }),
                none: () => BadRequest());
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var validationResult = _registerValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.First().ErrorMessage);
            }
            var result = await _bus.Send(new RegisterCommand(request.UserName, request.Password));
            return result.Match<IActionResult>(
                some: x => Ok(new UserResponse(x.Id, x.UserName)),
                none: () => BadRequest());
        }
    }
}
