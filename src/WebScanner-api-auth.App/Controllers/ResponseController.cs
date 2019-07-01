using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner_api_auth.Domain.Commands;
using WebScanner_api_auth.Requests;
using WebScanner_api_auth.Validators;

namespace WebScanner_api_auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly IMediator _bus;
        private readonly GetOrderResponsesFilteredRequestValidator _validator;

        public ResponseController(
            IMediator bus,
            GetOrderResponsesFilteredRequestValidator validator)
        {
            _bus = bus;
            _validator = validator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrderResponses([FromQuery] int orderId, [FromQuery] string orderType)
        {
            var result = await _bus.Send(new GetOrderResponsesCommand(orderId, orderType));
            return result.Match<IActionResult>(
                some: x => Ok(x),
                none: () => NoContent());

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GetOrderResponsesFiltered([FromBody] GetOrderResponsesFilteredRequest searchParameters)
        {
            var validationResult = _validator.Validate(searchParameters);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.First().ErrorMessage);
            }
            var result = await _bus.Send(new GetOrderResponsesFilteredCommand(
                searchParameters.OrderId,
                searchParameters.Type,
                searchParameters.DateAfter,
                searchParameters.DateBefore,
                searchParameters.Content));
            return result.Match<IActionResult>(
                some: x => Ok(x),
                none: () => NoContent());
        }
    }
}
