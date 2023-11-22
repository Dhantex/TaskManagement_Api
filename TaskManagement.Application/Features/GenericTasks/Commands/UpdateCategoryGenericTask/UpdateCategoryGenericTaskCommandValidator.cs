
using FluentValidation;

namespace TaskManagement.Application.Features.GenericTasks.Commands.UpdateCategoryGenericTask
{
    public class UpdateCategoryGenericTaskCommandValidator : AbstractValidator<UpdateCategoryGenericTaskCommand>
    {
        public UpdateCategoryGenericTaskCommandValidator()
        {
            RuleFor(p => p.CategoryId)
                .NotNull().WithMessage("{CategoryId} does not allow null values");

            RuleFor(p => p.GenericTaskId)
                .NotNull().WithMessage("{GenericTaskId} does not allow null values");
        }
    }
}
