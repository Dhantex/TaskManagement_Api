using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Identity.Models;

namespace TaskManagement.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "710ddf9a-b3f9-418a-a8ec-bfc2742427f7",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Name = "Administrator",
                    LasName = "System",
                    UserName = "admin",
                    NormalizedUserName = "admin",
                    PasswordHash = hasher.HashPassword(null, "CleanArchitecture2023!"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "832700a3-1ddc-40b8-a7fc-c15902ecd159",
                    Email = "assistant@localhost.com",
                    NormalizedEmail = "assistant@localhost.com",
                    Name = "Assistant",
                    LasName = "System",
                    UserName = "assistant",
                    NormalizedUserName = "assistant",
                    PasswordHash = hasher.HashPassword(null, "CleanArchitecture2023!"),
                    EmailConfirmed = true,
                }
                );
        }
    }
}
