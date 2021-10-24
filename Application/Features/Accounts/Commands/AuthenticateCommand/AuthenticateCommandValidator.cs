using FluentValidation;

namespace Application.Features.Accounts.Commands.AuthenticateCommand
{
    public class AuthenticateCommandValidator : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateCommandValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("{PropertyName} must be a valid email");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
