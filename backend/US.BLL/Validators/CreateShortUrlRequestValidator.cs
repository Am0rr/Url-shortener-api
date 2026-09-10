using FluentValidation;
using US.BLL.DTOs.ShortUrls;

namespace US.BLL.Validators;

public class CreateShortUrlRequestValidator : AbstractValidator<CreateShortUrlRequest>
{
    public CreateShortUrlRequestValidator()
    {
        RuleFor(s => s.OriginalUrl)
            .NotEmpty().WithMessage("Original url cannot be empty")
            .MaximumLength(2048).WithMessage("Original url must not exceed 500 characters.")
            .Must(BeAValidUrl).WithMessage("Original url must be a valid HTTP or HTTPS address.");
    }

    private static bool BeAValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}