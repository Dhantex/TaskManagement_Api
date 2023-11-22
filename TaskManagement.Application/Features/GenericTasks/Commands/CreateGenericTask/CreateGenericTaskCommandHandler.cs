using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Models.GenericTask;
using TaskManagement.Domain;

namespace TaskManagement.Application.Features.GenericTasks.Commands.CreateGenericTask
{
    public class CreateGenericTaskCommandHandler : IRequestHandler<CreateGenericTaskCommand, GenericTaskDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateGenericTaskCommandHandler> _logger;

        public CreateGenericTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateGenericTaskCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GenericTaskDto> Handle(CreateGenericTaskCommand request, CancellationToken cancellationToken)
        {
            var categoryExists = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);
            var statusExists = await _unitOfWork.StatusTypeRepository.GetByIdAsync(request.StatusTypeId);

            if (categoryExists == null || statusExists == null)
            {
                throw new Exception("Category or Status does not exist");
            }

            var addGenericTask = _mapper.Map<GenericTask>(request);

            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    var genericTask = await _unitOfWork.GenericTaskRepository.AddAsync(addGenericTask);

                    if (genericTask == null)
                    {
                        await _unitOfWork.RollbackTransactionAsync(transaction);
                        throw new Exception("could not create generic Task");
                    }

                    await _unitOfWork.GenericTaskRepository.CreateGenericTaskRelationships(request, genericTask.Id);
                    await _unitOfWork.CommitTransactionAsync(transaction);

                    _logger.LogInformation($"Generic Task {genericTask.Id} was successfully created");

                    var genericTaskDto = _mapper.Map<GenericTaskDto>(addGenericTask);
                    return genericTaskDto;
                }
                catch
                {
                    await _unitOfWork.RollbackTransactionAsync(transaction);
                    throw;
                }
            }
        }
    }

}
