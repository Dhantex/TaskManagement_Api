using TaskManagement.Domain.Common;

namespace TaskManagement.Domain
{
    public class Category: BaseDomainModel
    {
        public string? Name { get; set; }
        public ICollection<GenericTask> GenericTasks { get; set; } = new List<GenericTask>();
    }
}
