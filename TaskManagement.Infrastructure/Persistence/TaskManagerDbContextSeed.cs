using Microsoft.Extensions.Logging;
using TaskManagement.Domain;

namespace TaskManagement.Infrastructure.Persistence
{
    public class TaskManagerDbContextSeed
    {
        public static async Task SeedAsync(TaskManagerDbContext context, ILogger<TaskManagerDbContextSeed> logger)
        {
            // Seed Categories if they don't exist
            if (!context.Categories!.Any())
            {
                context.Categories!.AddRange(GetPreconfiguredCategories());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(TaskManagerDbContext).Name);
            }

            // Seed StatusTypes if they don't exist
            if (!context.StatusTypes!.Any())
            {
                context.StatusTypes!.AddRange(GetPreconfiguredGenericTaskStatuses());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(TaskManagerDbContext).Name);
            }

            // Seed GenericTasks if they don't exist
            if (!context.GenericTasks!.Any())
            {
                context.GenericTasks!.AddRange(GetPreconfiguredGenericTasks());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(TaskManagerDbContext).Name);
            }

            if (context.GenericTasks!.Any() && context.Categories!.Any() && context.StatusTypes!.Any())
            {
                var inProgressCategoryId = context.Categories!.FirstOrDefault(c => c.Name == "In Progress")?.Id;
                var activeStatusId = context.StatusTypes!.FirstOrDefault(s => s.Name == "Active")?.Id;

                if (inProgressCategoryId.HasValue && activeStatusId.HasValue)
                {
                    if (!context.GenericTaskCategories!.Any())
                    {
                        foreach (var task in context.GenericTasks!)
                        {
                            context.GenericTaskCategories!.Add(new GenericTaskCategory { GenericTaskId = task.Id, CategoryId = inProgressCategoryId.Value, IsActive = true });
                        }
                        await context.SaveChangesAsync();
                        logger.LogInformation("Seed GenericTaskCategories associated with context {DbContextName}", typeof(TaskManagerDbContext).Name);
                    }

                    if (!context.GenericTaskStatuses!.Any())
                    {
                        foreach (var task in context.GenericTasks!)
                        {
                            context.GenericTaskStatuses!.Add(new GenericTaskStatus { GenericTaskId = task.Id, TaskStatusId = activeStatusId.Value, IsActive = true });
                        }
                        await context.SaveChangesAsync();
                        logger.LogInformation("Seed GenericTaskStatuses associated with context {DbContextName}", typeof(TaskManagerDbContext).Name);
                    }
                }
            }

        }

        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>
        {
            new Category { CreatedBy = "system", Name = "In Progress" }, 
            new Category { CreatedBy = "system", Name = "To Be Assigned" },
            new Category { CreatedBy = "system", Name = "Completed" }
        };
        }

        private static IEnumerable<StatusType> GetPreconfiguredGenericTaskStatuses()
        {
            return new List<StatusType>
        {
            new StatusType { CreatedBy = "system", Name = "Active" },
            new StatusType { CreatedBy = "system", Name = "In Progress" }, 
            new StatusType { CreatedBy = "system", Name = "Overdue" },
            new StatusType { CreatedBy = "system", Name = "Closed" },
        };
        }

        private static IEnumerable<GenericTask> GetPreconfiguredGenericTasks()
        {
            return new List<GenericTask>
            {
                new GenericTask {
                    CreatedBy = "system",
                    Name = "Develop Real-Time Tracking Interface",
                    IsActive = true,
                    Description = "Design and develop a user interface for real-time tracking of trucks."
                },
                new GenericTask {
                    CreatedBy = "system",
                    Name = "Hardware Maintenance Check",
                    IsActive = true,
                    Description = "Perform regular maintenance checks on GPS tracking devices installed in trucks."
                },
                new GenericTask {
                    CreatedBy = "system",
                    Name = "Optimize Logistics Route Algorithm",
                    IsActive = true,
                    Description = "Optimize the algorithm used for calculating the most efficient logistics routes."
                },
                new GenericTask {
                    CreatedBy = "system",
                    Name = "Analyze Transportation Data Trends",
                    IsActive = true,
                    Description = "Analyze the collected geolocation data to identify trends and areas for improvement."
                },
                new GenericTask {
                    CreatedBy = "system",
                    Name = "Customer Support for Tracking System",
                    IsActive = true,
                    Description = "Provide customer support for queries related to the truck tracking system."
                }
            };
        }
    }
}
