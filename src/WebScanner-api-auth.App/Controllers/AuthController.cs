using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebScanner_api_auth.Domain.Commands;
using WebScanner_api_auth.Requests;
using WebScanner_api_auth.Responses;

namespace WebScanner_api_auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _bus;

        public AuthController(IMediator bus)
        {
            _bus = bus;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _bus.Send(new LoginCommand(request.UserName, request.Password));
            return result.Match<IActionResult>(
                some: x => Ok(new TokenResponse { Token = x }),
                none: () => BadRequest());
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _bus.Send(new RegisterCommand(request.UserName, request.Password));
            return result.Match<IActionResult>(
                some: x => Ok(new UserResponse(x.Id, x.UserName)),
                none: () => BadRequest());
        }
    }
}
