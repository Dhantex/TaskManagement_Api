using TaskManagement.Application.Features.GenericTasks.Commands.CreateGenericTask;
using TaskManagement.Application.Features.GenericTasks.Commands.UpdateCategoryGenericTask;
using TaskManagement.Application.Features.GenericTasks.Commands.UpdateStatusGenericTask;
using TaskManagement.Application.Features.GenericTasks.Queries.GetGenericTaskDetailsList;
using TaskManagement.Domain;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface IGenericTaskRepository: IAsyncRepository<GenericTask>
    {
        Task<IEnumerable<GenericTaskDetail>> GetGenericTaskDetails(int? categoryId, string? categoryName);
        Task<int> CreateGenericTaskRelationships(CreateGenericTaskCommand command, int genericTaskId);
        Task<int> UpdateGenericTaskCategory(UpdateCategoryGenericTaskCommand command);
        Task<int> UpdateGenericTaskStatusType(UpdateStatusGenericTaskCommand command);
    }
}
