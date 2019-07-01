using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScanner_api_auth.Requests;

namespace WebScanner_api_auth.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Hasło nie może być puste");
            RuleFor(x => x.UserName).NotEmpty().NotNull().WithMessage("Nazwa użytkownika nie może być pusta");
        }
    }
}
