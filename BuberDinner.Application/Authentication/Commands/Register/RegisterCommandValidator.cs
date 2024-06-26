namespace BuberDinner.Application.Authentication.Commands.Register;

using System.Data;
using FluentValidation;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(v => v.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");
        RuleFor(v => v.FirstName)
            .NotEmpty().WithMessage("First Name must required");
        RuleFor(v => v.LastName)
            .NotEmpty().WithMessage("Last Name must required");
    }
}