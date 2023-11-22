using Microsoft.EntityFrameworkCore.Storage;
using TaskManagement.Domain.Common;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; }
        IGenericTaskRepository GenericTaskRepository { get; }
        IStatusTypeRepository StatusTypeRepository { get; }
        IGenericTaskCategoryRepository GenericTaskCategoryRepository { get; }
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitTransactionAsync(IDbContextTransaction transaction);
        Task RollbackTransactionAsync(IDbContextTransaction transaction);
        Task<int> Complete();
    }
}
