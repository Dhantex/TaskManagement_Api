using MediatR;

namespace TaskManagement.Application.Features.GenericTasks.Commands.UpdateStatusGenericTask
{
    public class UpdateStatusGenericTaskCommand : IRequest
    {
        public int GenericTaskId { get; set; }
        public int StatusTypeId { get; set; }
    }
}
