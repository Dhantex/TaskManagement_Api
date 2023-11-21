using FluentValidation;
using TaskManagement.Application.Features.Categories.Commands.CreateCategory;

namespace TaskManagement.Application.Features.StatusTypes.Commands.CreateStatusTypes
{
    public class CreateStatusTypeCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateStatusTypeCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("{Name} It can not be null");

        }
    }
}
