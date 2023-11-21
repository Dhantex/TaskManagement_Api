using TaskManagement.Domain;

namespace TaskManagement.Application.Features.GenericTasks.Queries.GetGenericTaskList
{
    public class GenericTaskList
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<Category>? Categories { get; set; }
        public virtual ICollection<StatusType>? StatusTypes { get; set; }
    }
}
