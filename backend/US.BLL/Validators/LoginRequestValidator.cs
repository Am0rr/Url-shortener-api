using FluentValidation;
using US.BLL.DTOs.Identity;

namespace US.BLL.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(l => l.Email)
            .NotEmpty().WithMessage("Email address cannot be empty.")
            .EmailAddress().WithMessage("Email is not valid.")
            .MaximumLength(200).WithMessage("Email must not exceed 200 characters");

        RuleFor(l => l.Password)
            .NotEmpty().WithMessage("Password cannot be empty");
    }
}