using FluentValidation;
using US.BLL.DTOs.AboutContents;

namespace US.BLL.Validators;

public class UpdateAboutContentRequestValidator : AbstractValidator<UpdateAboutContentRequest>
{
    public UpdateAboutContentRequestValidator()
    {
        RuleFor(a => a.Text)
            .NotEmpty().WithMessage("Text cannot be empty")
            .MaximumLength(5000).WithMessage("Text must not exceed 5000 characters.");
    }
}