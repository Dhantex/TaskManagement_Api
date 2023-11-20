using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Identity.Configurations;
using TaskManagement.Identity.Models;

namespace TaskManagement.Identity
{
    public class TaskManagerIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public TaskManagerIdentityDbContext(DbContextOptions<TaskManagerIdentityDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());

        }
    }
}
