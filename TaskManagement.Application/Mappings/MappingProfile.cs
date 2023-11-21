using AutoMapper;
using TaskManagement.Application.Features.Categories.Commands.CreateCategory;
using TaskManagement.Application.Features.Categories.Queries.GetCategoriesList;
using TaskManagement.Application.Features.GenericTasks.Commands.CreateGenericTask;
using TaskManagement.Application.Features.GenericTasks.Commands.UpdateGenericTask;
using TaskManagement.Application.Features.StatusTypes.Commands.CreateStatusTypes;
using TaskManagement.Application.Features.StatusTypes.Queries;
using TaskManagement.Domain;

namespace TaskManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StatusType, StatusTypesList>(); 
            CreateMap<Category, CategoriesList>();
            CreateMap<CreateGenericTaskCommand, GenericTask>();
            CreateMap<UpdateGenericTaskCommand, GenericTask>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<CreateStatusTypeCommand, StatusType>();
        }
    }
}
