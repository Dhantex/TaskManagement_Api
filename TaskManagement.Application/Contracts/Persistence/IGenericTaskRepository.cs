using TaskManagement.Domain;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface IGenericTaskRepository: IAsyncRepository<GenericTask>
    {
        Task<IEnumerable<GenericTask>> GetGenericTaskByCategory(string categoryName);
    }
}
