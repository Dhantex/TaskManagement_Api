using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;


namespace TaskManagement.Application.Features.GenericTasks.Queries.GetGenericTaskDetailsList
{
    public class GetGenericTaskDetailQueryHandler : IRequestHandler<GetGenericTaskDetailQuery, List<GenericTaskDetail>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGenericTaskDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Consultation is carried out by category
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<GenericTaskDetail>> Handle(GetGenericTaskDetailQuery request, CancellationToken cancellationToken)
        {

            var genericTaskList = await _unitOfWork.GenericTaskRepository.GetGenericTaskDetails(request.CategoryId, request.CategoryName!);

            return _mapper.Map<List<GenericTaskDetail>>(genericTaskList);
        }
    }
}
