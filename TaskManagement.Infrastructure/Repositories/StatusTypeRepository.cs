using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories
{
    public class StatusTypeRepository : RepositoryBase<StatusType>, IStatusTypeRepository
    {
        public StatusTypeRepository(TaskManagerDbContext context) : base(context) { }
    }
}
