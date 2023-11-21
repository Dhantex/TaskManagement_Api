using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain;

namespace TaskManagement.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ILogger<CreateCategoryCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(ILogger<CreateCategoryCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryEntity = _mapper.Map<Category>(request);

            _unitOfWork.Repository<Category>().AddEntity(categoryEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError("Could not create category");
                throw new Exception("Could not create category");
            }

            return categoryEntity.Id;
        }
    }
}
