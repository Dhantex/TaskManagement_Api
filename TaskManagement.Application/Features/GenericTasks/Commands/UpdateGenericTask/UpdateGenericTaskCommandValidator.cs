using FluentValidation;

namespace TaskManagement.Application.Features.GenericTasks.Commands.UpdateGenericTask
{
    public class UpdateGenericTaskCommandValidator : AbstractValidator<UpdateGenericTaskCommand>
    {
        public UpdateGenericTaskCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull().WithMessage("{Name} does not allow null values");

            RuleFor(p => p.Description)
                .NotNull().WithMessage("{Description} does not allow null values");
        }
    }
}
