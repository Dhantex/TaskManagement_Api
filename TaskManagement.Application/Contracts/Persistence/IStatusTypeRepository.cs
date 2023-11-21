using TaskManagement.Domain;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface IStatusTypeRepository: IAsyncRepository<StatusType>
    {
    }
}
