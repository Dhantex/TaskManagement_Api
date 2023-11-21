
using MediatR;

namespace TaskManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesQuery : IRequest<List<CategoriesList>>
    {

        public int? CategoryId { get; set; }

        public GetCategoriesQuery(int? categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
