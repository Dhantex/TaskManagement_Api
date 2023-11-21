using AutoMapper;
using TaskManagement.Application.Features.Categories.Commands.CreateCategory;
using TaskManagement.Application.Features.GenericTasks.Commands.CreateGenericTask;
using TaskManagement.Application.Features.GenericTasks.Commands.UpdateGenericTask;
using TaskManagement.Application.Features.GenericTasks.Queries.GetGenericTaskList;
using TaskManagement.Application.Features.StatusTypes.Commands.CreateStatusTypes;
using TaskManagement.Domain;

namespace TaskManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GenericTask, GenericTaskList>();
            CreateMap<CreateGenericTaskCommand, GenericTask>();
            CreateMap<UpdateGenericTaskCommand, GenericTask>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<CreateStatusTypeCommand, StatusType>();
        }
    }
}
