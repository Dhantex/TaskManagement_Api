using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "ad56b66f-d40a-4980-bb1e-3236b3c221eb",
                    UserId = "710ddf9a-b3f9-418a-a8ec-bfc2742427f7"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "2c615cff-3d83-4bb7-a0c3-8d95d3ad696c",
                    UserId = "832700a3-1ddc-40b8-a7fc-c15902ecd159"
                })
                ;
        }
    }
}
