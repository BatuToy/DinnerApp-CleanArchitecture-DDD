using BuberDinner.Application.Authentication.Queries.Login;
using FluentValidation;

namespace BuberDinner.Application.Authentication.Queries;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator() 
    {
        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Email must required")
            .EmailAddress().WithMessage("Email is not valid");
        RuleFor(v => v.Password)
            .NotEmpty().WithMessage("Password must required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");
    }
}