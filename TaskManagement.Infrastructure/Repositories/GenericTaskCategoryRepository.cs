using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories
{
    public class GenericTaskCategoryRepository : RepositoryBase<GenericTaskCategory>, IGenericTaskCategoryRepository
    {
        public GenericTaskCategoryRepository(TaskManagerDbContext context) : base(context) { }
    }
}
