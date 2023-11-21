using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain;

namespace TaskManagement.Application.Features.StatusTypes.Commands.CreateStatusTypes
{
    public class CreateStatusTypeCommandHandler : IRequestHandler<CreateStatusTypeCommand, int>
    {
        private readonly ILogger<CreateStatusTypeCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateStatusTypeCommandHandler(ILogger<CreateStatusTypeCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateStatusTypeCommand request, CancellationToken cancellationToken)
        {
            var statusTypeEntity = _mapper.Map<StatusType>(request);

            _unitOfWork.Repository<StatusType>().AddEntity(statusTypeEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                _logger.LogError("Could not create Status Type");
                throw new Exception("Could not create Status Type");
            }

            return statusTypeEntity.Id;
        }
    }
}