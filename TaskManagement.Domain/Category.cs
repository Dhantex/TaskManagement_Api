using TaskManagement.Domain.Common;

namespace TaskManagement.Domain
{
    public class Category: BaseDomainModel
    {
        public Category()
        {
            GenericTasks = new HashSet<GenericTask>();
        }

        public string? Name { get; set; }
        public ICollection<GenericTask>? GenericTasks { get; set; }
    }
}
