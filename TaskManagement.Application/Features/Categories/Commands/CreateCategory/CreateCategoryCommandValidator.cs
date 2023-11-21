using FluentValidation;

namespace TaskManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("{Name} It can not be null");

        }
    }
}
