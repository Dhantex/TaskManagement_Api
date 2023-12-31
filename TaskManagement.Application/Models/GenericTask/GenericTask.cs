﻿namespace TaskManagement.Application.Models.GenericTask
{
    public class GenericTaskDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
