using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "ad56b66f-d40a-4980-bb1e-3236b3c221eb",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"

                },
                new IdentityRole
                {
                    Id = "2c615cff-3d83-4bb7-a0c3-8d95d3ad696c",
                    Name = "Assistant",
                    NormalizedName = "ASSISTANT"
                });
        }
    }
}
