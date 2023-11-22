using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;

namespace TaskManagement.Application.Features.GenericTasks.Commands.UpdateStatusGenericTask
{
    public class UpdateStatusGenericTaskCommandHandler : IRequestHandler<UpdateStatusGenericTaskCommand>
    {
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStatusGenericTaskCommandHandler> _logger;

        public UpdateStatusGenericTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateStatusGenericTaskCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateStatusGenericTaskCommand request, CancellationToken cancellationToken)
        {
            var genericTaskToUpdate = await _unitOfWork.GenericTaskRepository.GetByIdAsync(request.GenericTaskId);

            if (genericTaskToUpdate == null)
            {
                _logger.LogError($"The Generic Task id {request.GenericTaskId} was not found");
                throw new NotFoundException(nameof(GenericTasks), request.GenericTaskId);
            }

            await _unitOfWork.GenericTaskRepository.UpdateGenericTaskStatusType(request);
            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"Could not update Generic Task Status record");
            }

            _logger.LogInformation($"The operation was successful updating the Generic Task {request.GenericTaskId} and Category {request.StatusTypeId}");

            return Unit.Value;
        }
    }
}