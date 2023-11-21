using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Application.Features.GenericTasks.Queries.GetGenericTaskList
{
    public class GetGenericTaskListQueryHandler : IRequestHandler<GetGenericTaskListQuery, List<GenericTaskList>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGenericTaskListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
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
        public async Task<List<GenericTaskList>> Handle(GetGenericTaskListQuery request, CancellationToken cancellationToken)
        {

            var videoList = await _unitOfWork.GenericTaskRepository.GetGenericTaskByCategory(request.CategoryName);

            return _mapper.Map<List<GenericTaskList>>(videoList);
        }
    }
}
