using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(TaskManagerDbContext context) : base(context) { }
    }
}
