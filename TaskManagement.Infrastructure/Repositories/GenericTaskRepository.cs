using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.GenericTasks.Commands.CreateGenericTask;
using TaskManagement.Application.Features.GenericTasks.Commands.UpdateCategoryGenericTask;
using TaskManagement.Application.Features.GenericTasks.Commands.UpdateStatusGenericTask;
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
                            NameStatusType = status.Name,
                            CreatedBy = task.CreatedBy,
                            CreatedDate = task.CreatedDate,
                            DueDate = task.DueDate

                        };

            return await query.ToListAsync();
        }


        public async Task<int> CreateGenericTaskRelationships(CreateGenericTaskCommand command, int genericTaskId)
        {
            // Associate the task with the category
            var taskCategory = new GenericTaskCategory
            {
                GenericTaskId = genericTaskId,
                CategoryId = command.CategoryId,
                IsActive = true
            };

            // Associate the task with the status
            var taskStatusType = new GenericTaskStatusType
            {
                GenericTaskId = genericTaskId,
                StatusTypeId = command.StatusTypeId,
                IsActive = true
            };

            await _context.GenericTaskCategories!.AddAsync(taskCategory);
            await _context.GenericTaskStatusTypes!.AddAsync(taskStatusType);

            return genericTaskId;
        }

        public async Task<int> UpdateGenericTaskCategory(UpdateCategoryGenericTaskCommand command)
        {
            var existingRelation = await _context.GenericTaskCategories!.FirstOrDefaultAsync(c => c.GenericTaskId == command.GenericTaskId
                                                           && c.CategoryId == command.CategoryId);

            var deactivateRelationship = await _context.GenericTaskCategories!.FirstOrDefaultAsync(c => c.GenericTaskId == command.GenericTaskId
                                                                       && c.IsActive);

            if (existingRelation == null)
            {
                var updateGenericTaskCategory = new GenericTaskCategory
                {
                    GenericTaskId = command.GenericTaskId,
                    CategoryId = command.CategoryId,
                    IsActive = true
                };

                await _context.GenericTaskCategories!.AddAsync(updateGenericTaskCategory);
            }
            else
            {
                existingRelation.IsActive = !existingRelation.IsActive;
                _context.GenericTaskCategories?.Update(existingRelation);
            }

            
            if(deactivateRelationship != null)
            {
                deactivateRelationship.IsActive = false;
                _context.GenericTaskCategories?.Update(deactivateRelationship);
            }

            return command.CategoryId;
        }

        public async Task<int> UpdateGenericTaskStatusType(UpdateStatusGenericTaskCommand command)
        {
            var existingRelation = await _context.GenericTaskStatusTypes!.FirstOrDefaultAsync(c => c.GenericTaskId == command.GenericTaskId
                                                           && c.StatusTypeId == command.StatusTypeId);

            var deactivateRelationship = await _context.GenericTaskStatusTypes!.FirstOrDefaultAsync(c => c.GenericTaskId == command.GenericTaskId
                                                                       && c.IsActive);

            if (existingRelation == null)
            {
                var updateGenericTaskStatusType = new GenericTaskStatusType
                {
                    GenericTaskId = command.GenericTaskId,
                    StatusTypeId = command.StatusTypeId,
                    IsActive = true
                };

                await _context.GenericTaskStatusTypes!.AddAsync(updateGenericTaskStatusType);
            }
            else
            {
                existingRelation.IsActive = !existingRelation.IsActive;
                _context.GenericTaskStatusTypes?.Update(existingRelation);
            }


            if (deactivateRelationship != null)
            {
                deactivateRelationship.IsActive = false;
                _context.GenericTaskStatusTypes?.Update(deactivateRelationship);
            }

            return command.StatusTypeId;
        }
    }
}
