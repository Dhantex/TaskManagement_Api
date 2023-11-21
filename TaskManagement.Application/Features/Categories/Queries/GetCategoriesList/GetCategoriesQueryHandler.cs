using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;


namespace TaskManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    internal class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoriesList>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CategoriesList>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {

            var categoryList = await _unitOfWork.CategoryRepository.GetAllAsync();

            return _mapper.Map<List<CategoriesList>>(categoryList);
        }
    }
}
