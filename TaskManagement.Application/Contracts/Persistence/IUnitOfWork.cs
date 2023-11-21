using TaskManagement.Domain.Common;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IGenericTaskRepository GenericTaskRepository { get; }
        IStatusTypeRepository StatusTypeRepository { get; }
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
