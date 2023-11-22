using MediatR;

namespace TaskManagement.Application.Features.GenericTasks.Commands.UpdateCategoryGenericTask
{
    public class UpdateCategoryGenericTaskCommand : IRequest
    {
        public int GenericTaskId { get; set; }
        public int CategoryId { get; set; }
    }
}
