using Microsoft.AspNetCore.Identity;

namespace TaskManagement.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string LasName { get; set; } = string.Empty;

    }
}
