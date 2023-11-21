using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories
{
    public class GenericTaskRepository : RepositoryBase<GenericTask>, IGenericTaskRepository
    {
        public GenericTaskRepository(TaskManagerDbContext context) : base(context) { }

        public async Task<IEnumerable<GenericTask>> GetGenericTaskByCategory(string categoryName) 
        {
            return await _context.GenericTasks!
                .Include(g => g.Categories) 
                .Where(g => g.Categories!.Any(c => c.Name == categoryName))
                .ToListAsync();
        }
    }
}
