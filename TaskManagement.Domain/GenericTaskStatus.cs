﻿using TaskManagement.Domain.Common;

namespace TaskManagement.Domain
{
    public  class GenericTaskStatus:BaseDomainModel
    {
        public int GenericTaskId { get; set; }
        public int TaskStatusId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}