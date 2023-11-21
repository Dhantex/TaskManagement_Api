using TaskManagement.Application.Features.GenericTasks.Queries.GetGenericTaskDetailsList;
using TaskManagement.Domain;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface IGenericTaskRepository: IAsyncRepository<GenericTask>
    {
        Task<IEnumerable<GenericTaskDetail>> GetGenericTaskDetails(int? categoryId, string? categoryName);
    }
}
