using FluentValidation;

namespace Application.Features.Catalogs.Commands.CreateCatalogCommand
{
    public class CreateCatalogCommandValidator : AbstractValidator<CreateCatalogCommand>
    {
        public CreateCatalogCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(80).WithMessage("{PropertyName} must not exceed {MaxLength}");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(150).WithMessage("{PropertyName} must not exceed {MaxLength}");
        }
    }
}
