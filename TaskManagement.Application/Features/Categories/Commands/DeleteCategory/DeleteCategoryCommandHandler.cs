using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;
using TaskManagement.Domain;

namespace TaskManagement.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteCategoryCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);

            if (categoryToDelete == null)
            {
                _logger.LogError($"{request.Id} The category does not exist in the system");
                throw new NotFoundException(nameof(Category), request.Id);
            }

            _unitOfWork.CategoryRepository.DeleteEntity(categoryToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"The {request.Id} category was successfully eliminated");

            return Unit.Value;

        }
    }
}
