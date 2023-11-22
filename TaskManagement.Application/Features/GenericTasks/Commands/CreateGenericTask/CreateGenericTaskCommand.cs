using MediatR;
using TaskManagement.Application.Models.GenericTask;

namespace TaskManagement.Application.Features.GenericTasks.Commands.CreateGenericTask
{
    public class CreateGenericTaskCommand : IRequest<GenericTaskDto>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; } = DateTime.Now.AddDays(30);
        public int CategoryId { get; set; }
        public int StatusTypeId { get; set; }

    }
}
