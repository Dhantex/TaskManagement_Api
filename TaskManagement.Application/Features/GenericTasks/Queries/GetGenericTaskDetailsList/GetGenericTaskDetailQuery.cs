using MediatR;

namespace TaskManagement.Application.Features.GenericTasks.Queries.GetGenericTaskDetailsList
{
    public class GetGenericTaskDetailQuery : IRequest<List<GenericTaskDetail>>
    {

        public string? CategoryName { get; set; }
        public int? CategoryId { get; set; }

        public GetGenericTaskDetailQuery(string? categoryName, int? categoryId)
        {
            CategoryName = categoryName;
            CategoryId = categoryId;
        }
    }
}