using TaskManagement.Domain.Common;

namespace TaskManagement.Domain
{
    public class GenericTask: BaseDomainModel
    {
        public GenericTask()
        {
            Categories = new HashSet<Category>();
            StatusTypes = new HashSet<StatusType>();
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Category>? Categories { get; set; }
        public virtual ICollection<StatusType>? StatusTypes { get; set; }
    }
}
