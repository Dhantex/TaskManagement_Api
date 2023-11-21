using TaskManagement.Domain.Common;

namespace TaskManagement.Domain
{
    public class StatusType: BaseDomainModel
    {
        public StatusType()
        {
            GenericTasks = new HashSet<GenericTask>();
        }

        public string? Name { get; set; }
        public ICollection<GenericTask>? GenericTasks { get; set; }
    }
}
