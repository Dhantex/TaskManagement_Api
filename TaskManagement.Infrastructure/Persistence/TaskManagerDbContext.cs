using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain;
using TaskManagement.Domain.Common;

namespace TaskManagement.Infrastructure.Persistence
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "system";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configuring the many-to-many relationship between GenericTasks and Categories
            modelBuilder.Entity<GenericTask>()
                .HasMany(g => g.Categories)
                .WithMany(c => c.GenericTasks)
                .UsingEntity<GenericTaskCategory>(
                    pt => pt.HasKey(e => new { e.GenericTaskId, e.CategoryId }));

            // Configuring the many-to-many relationship between GenericTasks and TaskStatuses
            modelBuilder.Entity<GenericTask>()
                .HasMany(g => g.TaskStatuses)
                .WithMany(t => t.GenericTasks)
                .UsingEntity<GenericTaskStatus>(
                    pt => pt.HasKey(e => new { e.GenericTaskId, e.TaskStatusId }));
        }

        public DbSet<GenericTask>? GenericTasks { get; set; }
        public DbSet<Category>? Categories { get; set; }

        public DbSet<GenericTaskCategory>? GenericTaskCategories { get; set; }
        public DbSet<GenericTaskStatus>? GenericTaskStatuses { get; set; }
        public DbSet<StatusType>? StatusTypes { get; set; }

    }
}
