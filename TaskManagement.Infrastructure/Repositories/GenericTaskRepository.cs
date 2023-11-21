using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.GenericTasks.Queries.GetGenericTaskDetailsList;
using TaskManagement.Domain;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories
{
    public class GenericTaskRepository : RepositoryBase<GenericTask>, IGenericTaskRepository
    {
        public GenericTaskRepository(TaskManagerDbContext context) : base(context) { }

        public async Task<IEnumerable<GenericTaskDetail>> GetGenericTaskDetails(int? categoryId, string? categoryName)
        {
            var query = from task in _context.GenericTasks
                        join taskCategory in _context.GenericTaskCategories on task.Id equals taskCategory.GenericTaskId
                        join category in _context.Categories on taskCategory.CategoryId equals category.Id
                        join taskStatus in _context.GenericTaskStatusTypes on task.Id equals taskStatus.GenericTaskId
                        join status in _context.StatusTypes on taskStatus.StatusTypeId equals status.Id
                        where taskCategory.IsActive && taskStatus.IsActive && task.IsActive
                              && (categoryId == 0 || category.Id == categoryId)
                              && (categoryName == null || category.Name == categoryName)
                        select new GenericTaskDetail
                        {
                            Id = task.Id,
                            NameGenericTask = task.Name,
                            Description = task.Description,
                            CategoryId = category.Id,
                            NameCategory = category.Name,
                            StatusTypeId = status.Id,
                            NameStatusType = status.Name
                        };

            return await query.ToListAsync();
        }
    }
}
