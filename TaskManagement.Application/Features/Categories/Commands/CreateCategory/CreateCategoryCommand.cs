using MediatR;

namespace TaskManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
    }
}
