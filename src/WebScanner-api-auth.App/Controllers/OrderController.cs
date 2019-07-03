using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebScanner_api_auth.Domain.Commands;
using WebScanner_api_auth.Infrastructure.Tokens;
using WebScanner_api_auth.Requests;

namespace WebScanner_api_auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _bus;

        public OrderController(IMediator bus)
        {
            _bus = bus;
        }

        [Authorize]
        [HttpGet("Server")]
        public async Task<IActionResult> GetServerOrdersForUser()
        {
            var userId = TokenDecryptor.DecryptUserId(this.User.Identity as ClaimsIdentity);
            var result = await _bus.Send(new GetServerOrdersCommand(userId));
            return result.Match<IActionResult>(
                some: x => Ok(x),
                none: () => NoContent());
        }

        [Authorize]
        [HttpGet("Html")]
        public async Task<IActionResult> GetHtmlOrdersForUser()
        {
            var userId = TokenDecryptor.DecryptUserId(this.User.Identity as ClaimsIdentity);
            var result = await _bus.Send(new GetHtmlOrdersCommand(userId));
            return result.Match<IActionResult>(
               some: x => Ok(x),
               none: () => NoContent());
        }

        [Authorize]
        [HttpPost("Server")]
        public async Task<IActionResult> AddServerOrder([FromBody] AddServerOrderRequest request)
        {
            var userId = TokenDecryptor.DecryptUserId(this.User.Identity as ClaimsIdentity);
            var result = await _bus.Send(new AddServerOrderCommand(userId, request.Frequency, request.TargetAddress, request.Question));
            return result.Match<IActionResult>(
                some: x => Ok(x),
                () => BadRequest());
        }

        [Authorize]
        [HttpPost("Html")]
        public async Task<IActionResult> AddHtmlOrder([FromBody] AddHtmlOrderRequest request)
        {
            var userId = TokenDecryptor.DecryptUserId(this.User.Identity as ClaimsIdentity);
            var result = await _bus.Send(new AddHtmlOrderCommand(userId, request.Frequency, request.TargetAddress, request.SubjectOfQuestion));
            return result.Match<IActionResult>(
                some: x => Ok(x),
                () => BadRequest());
        }

        [Authorize]
        [HttpDelete("Html")]
        public async Task<IActionResult> DeleteHtmlOrdeR([FromQuery] int orderId)
        {
            var userId = TokenDecryptor.DecryptUserId(this.User.Identity as ClaimsIdentity);
            var result = await _bus.Send(new DeleteHtmlOrderCommand(userId, orderId));
            return result.Match<IActionResult>(
                some: x => Ok(x),
                none: () => BadRequest());
        }

        [Authorize]
        [HttpDelete("Server")]
        public async Task<IActionResult> DeleteServerOrdeR([FromQuery] int orderId)
        {
            var userId = TokenDecryptor.DecryptUserId(this.User.Identity as ClaimsIdentity);
            var result = await _bus.Send(new DeleteServerOrderCommand(userId, orderId));
            return result.Match<IActionResult>(
                some: x => Ok(x),
                none: () => BadRequest());
        }

        [Authorize]
        [HttpGet("Html/Order")]
        public async Task<IActionResult> GetHtmlOrder([FromQuery] int id)
        {
            var userId = TokenDecryptor.DecryptUserId(this.User.Identity as ClaimsIdentity);
            var result = await _bus.Send(new GetHtmlOrderCommand(userId, id));
            return result.Match<IActionResult>(
                some: x => Ok(x),
                none: () => BadRequest());
        }

        [Authorize]
        [HttpGet("Server/Order")]
        public async Task<IActionResult> GetServerOrder([FromQuery] int id)
        {
            var userId = TokenDecryptor.DecryptUserId(this.User.Identity as ClaimsIdentity);
            var result = await _bus.Send(new GetServerOrderCommand(userId, id));
            return result.Match<IActionResult>(
                some: x => Ok(x),
                none: () => BadRequest());
        }
    }
}
