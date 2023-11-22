namespace TaskManagement.Application.Features.GenericTasks.Queries.GetGenericTaskDetailsList
{
    public class GenericTaskDetail
    {
        public int Id { get; set; }
        public string NameGenericTask { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string NameCategory { get; set; } = string.Empty;
        public int StatusTypeId { get; set; }
        public string NameStatusType { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
