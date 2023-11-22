using FluentValidation;

namespace TaskManagement.Application.Features.GenericTasks.Commands.UpdateStatusGenericTask
{
    public class UpdateStatusGenericTaskCommandValidator : AbstractValidator<UpdateStatusGenericTaskCommand>
    {
        public UpdateStatusGenericTaskCommandValidator()
        {
            RuleFor(p => p.StatusTypeId)
                .NotNull().WithMessage("{StatusTypeId} does not allow null values");

            RuleFor(p => p.GenericTaskId)
                .NotNull().WithMessage("{GenericTaskId} does not allow null values");
        }
    }
}
