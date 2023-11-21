using FluentValidation;

namespace TaskManagement.Application.Features.GenericTasks.Commands.CreateGenericTask
{
    public class CreateGenericTaskCommandValidator : AbstractValidator<CreateGenericTaskCommand>
    {
        public CreateGenericTaskCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} can not be blank")
                .NotNull()
                .MaximumLength(100).WithMessage("{Name} cannot exceed 100 characters");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("La {Url} no puede estar en blanco")
                .NotNull()
                .MaximumLength(250).WithMessage("{Description} cannot exceed 250 characters");

            RuleFor(p => p.CategoryId)
                .GreaterThan(0).WithMessage("{CategoryId} can not be blank or zero");

            RuleFor(p => p.StatusTypeId)
                .GreaterThan(0).WithMessage("{TaskStatusId} can not be blank or zero")
                .NotNull();
        }
    }
}
