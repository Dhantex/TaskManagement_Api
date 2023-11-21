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

            modelBuilder.Entity<Category>()
                .HasMany(p => p.GenericTasks)
                .WithMany(t => t.Categories)
                .UsingEntity<GenericTaskCategory>(
                    pt => pt.HasKey(e => new { e.GenericTaskId, e.CategoryId })
                );


            modelBuilder.Entity<StatusType>()
                .HasMany(p => p.GenericTasks)
                .WithMany(t => t.StatusTypes)
                .UsingEntity<GenericTaskStatusType>(
                    pt => pt.HasKey(e => new { e.GenericTaskId, e.TaskStatusId })
                );
        }

        public DbSet<GenericTask>? GenericTasks { get; set; }
        public DbSet<Category>? Categories { get; set; }

        public DbSet<GenericTaskCategory>? GenericTaskCategories { get; set; }
        public DbSet<GenericTaskStatusType>? GenericTaskStatusTypes { get; set; }
        public DbSet<StatusType>? StatusTypes { get; set; }

    }
}
