using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;

namespace TaskManagement.Application.Features.GenericTasks.Commands.UpdateCategoryGenericTask
{
    public class UpdateCategoryGenericTaskCommandHandler : IRequestHandler<UpdateCategoryGenericTaskCommand>
    {
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCategoryGenericTaskCommandHandler> _logger;

        public UpdateCategoryGenericTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCategoryGenericTaskCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateCategoryGenericTaskCommand request, CancellationToken cancellationToken)
        {
            var genericTaskToUpdate = await _unitOfWork.GenericTaskRepository.GetByIdAsync(request.GenericTaskId);

            if (genericTaskToUpdate == null)
            {
                _logger.LogError($"The Generic Task id {request.GenericTaskId} was not found");
                throw new NotFoundException(nameof(GenericTasks), request.GenericTaskId);
            }

            await _unitOfWork.GenericTaskRepository.UpdateGenericTaskCategory(request);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"Could not update Generic Task Category record");
            }

            _logger.LogInformation($"The operation was successful updating the Generic Task {request.GenericTaskId} and Category {request.CategoryId}");

            return Unit.Value;
        }
    }
}
