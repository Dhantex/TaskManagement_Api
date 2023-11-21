using MediatR;

namespace TaskManagement.Application.Features.GenericTasks.Commands.DeleteGenericTask
{
    public class DeleteGenericTaskCommand : IRequest
    {
        public int Id { get; set; }
    }
}
