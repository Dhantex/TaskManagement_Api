using MediatR;

namespace TaskManagement.Application.Features.StatusTypes.Commands.CreateStatusTypes
{
    public class CreateStatusTypeCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}
