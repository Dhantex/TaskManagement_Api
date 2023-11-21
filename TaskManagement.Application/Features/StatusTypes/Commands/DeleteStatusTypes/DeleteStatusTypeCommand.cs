using MediatR;

namespace TaskManagement.Application.Features.StatusTypes.Commands.DeleteStatusTypes
{
    public class DeleteStatusTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
