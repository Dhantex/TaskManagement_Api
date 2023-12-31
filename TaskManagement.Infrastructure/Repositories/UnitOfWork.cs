﻿using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain.Common;
using TaskManagement.Infrastructure.Persistence;

namespace TaskManagement.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly TaskManagerDbContext _context;


        private ICategoryRepository _categoryRepository;
        private IGenericTaskRepository _genericTaskRepository;
        private IStatusTypeRepository _statusTypeRepository;
        private IGenericTaskCategoryRepository _genericTaskCategoryRepository;

        public ICategoryRepository CategoryRepository => _categoryRepository ??= new CategoryRepository(_context);
        public IGenericTaskRepository GenericTaskRepository => _genericTaskRepository ??= new GenericTaskRepository(_context);
        public IStatusTypeRepository StatusTypeRepository => _statusTypeRepository ??= new StatusTypeRepository(_context);
        public IGenericTaskCategoryRepository GenericTaskCategoryRepository => _genericTaskCategoryRepository ??= new GenericTaskCategoryRepository(_context);

        public UnitOfWork(TaskManagerDbContext context)
        {
            _context = context;
        }

        public TaskManagerDbContext TaskManagerDbContext => _context;

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var respositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, respositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type];
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                throw new Exception("Error when try CommitTransactionAsync");
            }
        }

        public async Task RollbackTransactionAsync(IDbContextTransaction transaction)
        {
            await transaction.RollbackAsync();
        }

    }
}
