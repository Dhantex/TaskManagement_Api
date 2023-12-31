﻿using MediatR;

namespace TaskManagement.Application.Features.GenericTasks.Commands.UpdateGenericTask
{
    public class UpdateGenericTaskCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
