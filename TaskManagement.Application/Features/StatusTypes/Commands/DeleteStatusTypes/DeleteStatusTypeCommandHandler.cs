using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;
using TaskManagement.Domain;

namespace TaskManagement.Application.Features.StatusTypes.Commands.DeleteStatusTypes
{
    public class DeleteStatusTypeCommandHandler : IRequestHandler<DeleteStatusTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStatusTypeCommandHandler> _logger;

        public DeleteStatusTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteStatusTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteStatusTypeCommand request, CancellationToken cancellationToken)
        {
            var statusTypeToDelete = await _unitOfWork.StatusTypeRepository.GetByIdAsync(request.Id);

            if (statusTypeToDelete == null)
            {
                _logger.LogError($"{request.Id} The status type does not exist in the system");
                throw new NotFoundException(nameof(Category), request.Id);
            }

            _unitOfWork.StatusTypeRepository.DeleteEntity(statusTypeToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"The {request.Id} status type was successfully eliminated");

            return Unit.Value;

        }
    }
}
