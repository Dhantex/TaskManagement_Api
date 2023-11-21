using MediatR;

namespace TaskManagement.Application.Features.StatusTypes.Queries
{
    public class GetStatusTypesQuery : IRequest<List<StatusTypesList>>
    {
        public int? StatusTypeId { get; set; }

        public GetStatusTypesQuery(int? statusTypeId)
        {
            StatusTypeId = statusTypeId;
        }
    }
}
