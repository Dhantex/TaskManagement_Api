using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;


namespace TaskManagement.Application.Features.StatusTypes.Queries
{
    public class GetStatusTypesQueryHandler : IRequestHandler<GetStatusTypesQuery, List<StatusTypesList>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetStatusTypesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<StatusTypesList>> Handle(GetStatusTypesQuery request, CancellationToken cancellationToken)
        {

            var statusTypeList = await _unitOfWork.StatusTypeRepository.GetAllAsync();

            return _mapper.Map<List<StatusTypesList>>(statusTypeList);
        }
    }
}
