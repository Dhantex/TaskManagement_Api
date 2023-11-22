using AutoMapper;
using TaskManagement.Application.Features.Categories.Commands.CreateCategory;
using TaskManagement.Application.Features.Categories.Queries.GetCategoriesList;
using TaskManagement.Application.Features.GenericTasks.Commands.CreateGenericTask;
using TaskManagement.Application.Features.GenericTasks.Commands.UpdateCategoryGenericTask;
using TaskManagement.Application.Features.GenericTasks.Commands.UpdateGenericTask;
using TaskManagement.Application.Features.StatusTypes.Commands.CreateStatusTypes;
using TaskManagement.Application.Features.StatusTypes.Queries;
using TaskManagement.Application.Models.GenericTask;
using TaskManagement.Domain;

namespace TaskManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdateCategoryGenericTaskCommand, GenericTaskCategory>();
            CreateMap<GenericTask, GenericTaskDto>();
            CreateMap<StatusType, StatusTypesList>(); 
            CreateMap<Category, CategoriesList>();
            CreateMap<CreateGenericTaskCommand, GenericTask>().ReverseMap();
            CreateMap<UpdateGenericTaskCommand, GenericTask>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<CreateStatusTypeCommand, StatusType>();
        }
    }
}
