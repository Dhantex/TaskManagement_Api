using TaskManagement.Domain.Common;

namespace TaskManagement.Domain
{
    public class GenericTask: BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Category>? Categories { get; set; }
        public ICollection<StatusType>? TaskStatuses { get; set; }
    }
}
