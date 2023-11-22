using TaskManagement.Domain;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface IGenericTaskCategoryRepository : IAsyncRepository<GenericTaskCategory>
    {
    }
}