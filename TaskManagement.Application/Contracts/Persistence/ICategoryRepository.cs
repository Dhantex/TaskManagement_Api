using TaskManagement.Domain;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface ICategoryRepository:IAsyncRepository<Category>
    {
    }
}
