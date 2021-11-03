using FluentValidation;

namespace Application.Features.Catalogs.Commands.DeleteCatalogCommand
{
    public class DeleteCatalogCommandValidator : AbstractValidator<DeleteCatalogCommand>
    {
        public DeleteCatalogCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
        }
    }
}
