using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner_api_auth.Requests;

namespace WebScanner_api_auth.Validators
{
    public class GetOrderResponsesFilteredRequestValidator : AbstractValidator<GetOrderResponsesFilteredRequest>
    {
        public GetOrderResponsesFilteredRequestValidator()
        {
            RuleFor(x => x.OrderId).NotNull().NotEmpty().WithMessage("Numer zlecenia nie może być pusty");
            RuleFor(x => x.Type).NotNull().NotEmpty().WithMessage("Typ zlecenia nie może być pusty");
        }
    }
}
