using MediatR;

namespace TaskManagement.Application.Features.GenericTasks.Queries.GetGenericTaskList
{
    public class GetGenericTaskListQuery : IRequest<List<GenericTaskList>>
    {
        
        public string CategoryName { get; set; } = string.Empty;
        
        public GetGenericTaskListQuery(string categoryName)
        {
            CategoryName = categoryName ?? throw new ArgumentException(nameof(categoryName));
        }
    }
}
