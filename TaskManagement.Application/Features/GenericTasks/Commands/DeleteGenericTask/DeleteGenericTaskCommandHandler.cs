using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;
using TaskManagement.Domain;

namespace TaskManagement.Application.Features.GenericTasks.Commands.DeleteGenericTask
{
    public class DeleteGenericTaskCommandHandler : IRequestHandler<DeleteGenericTaskCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteGenericTaskCommandHandler> _logger;

        public DeleteGenericTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteGenericTaskCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteGenericTaskCommand request, CancellationToken cancellationToken)
        {
            var genericTaskToDelete = await _unitOfWork.GenericTaskRepository.GetByIdAsync(request.Id);

            if (genericTaskToDelete == null)
            {
                _logger.LogError($"{request.Id} generic task does not exist in the system");
                throw new NotFoundException(nameof(GenericTask), request.Id);
            }

            _unitOfWork.GenericTaskRepository.DeleteEntity(genericTaskToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"The {request.Id} generic task was successfully deleted");

            return Unit.Value;

        }
    }
}
