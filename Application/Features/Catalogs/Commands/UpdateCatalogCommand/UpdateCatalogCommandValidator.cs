using FluentValidation;

namespace Application.Features.Catalogs.Commands.UpdateCatalogCommand
{
    public class UpdateCatalogCommandValidator : AbstractValidator<UpdateCatalogCommand>
    {
        public UpdateCatalogCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(80).WithMessage("{PropertyName} must not exceed {MaxLength}");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(150).WithMessage("{PropertyName} must not exceed {MaxLength}");
        }
    }
}
