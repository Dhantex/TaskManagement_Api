using TaskManagement.Domain.Common;

namespace TaskManagement.Domain
{
    public class GenericTaskCategory: BaseDomainModel
    {
        public int GenericTaskId { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
