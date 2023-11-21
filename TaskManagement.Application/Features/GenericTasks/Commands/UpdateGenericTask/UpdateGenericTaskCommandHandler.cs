using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;

namespace TaskManagement.Application.Features.GenericTasks.Commands.UpdateGenericTask
{
    public class UpdateGenericTaskCommandHandler : IRequestHandler<UpdateGenericTaskCommand>
    {
        //private readonly IStreamerRepository _streamerRepository;
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateGenericTaskCommandHandler> _logger;

        public UpdateGenericTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateGenericTaskCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateGenericTaskCommand request, CancellationToken cancellationToken)
        {
            var genericTaskToUpdate = await _unitOfWork.GenericTaskRepository.GetByIdAsync(request.Id);


            if (genericTaskToUpdate == null)
            {
                _logger.LogError($"The Generic Task id {request.Id} was not found");
                throw new NotFoundException(nameof(GenericTasks), request.Id);
            }

            _mapper.Map(request, genericTaskToUpdate, typeof(UpdateGenericTaskCommand), typeof(Stream));

            _unitOfWork.GenericTaskRepository.UpdateEntity(genericTaskToUpdate);
            await _unitOfWork.Complete();

            _logger.LogInformation($"The operation was successful updating the Generic Task {request.Id}");

            return Unit.Value;
        }
    }
}
