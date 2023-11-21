using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain;

namespace TaskManagement.Application.Features.GenericTasks.Commands.CreateGenericTask
{
    public class CreateGenericTaskCommandHandler : IRequestHandler<CreateGenericTaskCommand, int>
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

        public async Task<int> Handle(CreateGenericTaskCommand request, CancellationToken cancellationToken)
        {

            var categoryExists = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);
            var statusExists = await _unitOfWork.StatusTypeRepository.GetByIdAsync(request.StatusTypeId);

            if (categoryExists == null|| statusExists == null )
            {
                throw new Exception("Category or Status does not exist");
            }

            var genericTaskEntity = _mapper.Map<GenericTask>(request);

            _unitOfWork.GenericTaskRepository.AddEntity(genericTaskEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"Could not insert generic Task record");
            }

            _logger.LogInformation($"Generic Task {genericTaskEntity.Id} was successfully created");

            return genericTaskEntity.Id;
        }
    }

}
