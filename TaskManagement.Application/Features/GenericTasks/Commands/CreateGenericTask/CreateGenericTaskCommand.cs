using MediatR;

namespace TaskManagement.Application.Features.GenericTasks.Commands.CreateGenericTask
{
    public class CreateGenericTaskCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int TaskStatusId { get; set; }

    }
}
